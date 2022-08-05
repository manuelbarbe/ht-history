
using HtHistory.Core.DataBridges;
using HtHistory.Core.DataBridges.CacheBridges;
using HtHistory.Core.DataBridges.ChppBridges;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using HtHistory.Core.DataBridges.ProxyBridges;
using HtHistory.Data.Types;

IChppAccessor accessor = new ChppFilesystemAccessor("/data", new ChppOnlineAccessor("JWp24dkskEGTXCvH", "n5HjBPDyZq4xqpIY", null));
//IChppAccessor accessor = new ChppOnlineAccessor("JWp24dkskEGTXCvH", "n5HjBPDyZq4xqpIY", null);
DataBridgeFactory dbf = new DataBridgeFactory();
dbf.MatchArchiveBridge = new ChppMatchArchiveBridge(accessor);
dbf.MatchDetailsBridge = //new BridgeChain<MatchDetails>(
                         //new CacheBridge<MatchDetails>(),
                         //new BridgeChain<MatchDetails>(
                         //new DatabaseMatchDetailsBridge(),
                                    new ChppMatchDetailsBridge(accessor);//);
dbf.TeamDetailsBridge = new ChppTeamDetailsBridge(accessor);
dbf.PlayersBridge = new ChppPlayersBridge(accessor);
dbf.TransfersBridge = new ChppTransferHistoryBridge(accessor);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/teams/{team_id}/details", async (uint team_id) =>
    await Task.Run(() => dbf.TeamDetailsBridge.GetTeamDetails(team_id)
        is TeamDetails td
            ? Results.Ok(td)
            : Results.NotFound())); ;

app.MapGet("/teams/{team_id}/matcharchive", async (uint team_id, DateTime start, DateTime end) =>
    await Task.Run(() => dbf.MatchArchiveBridge.GetMatches(team_id, start, end)
        is MatchArchive ma
            ? Results.Ok(ma)
            : Results.NotFound()));

app.MapGet("/teams/{team_id}/players", async (uint team_id) =>
    await Task.Run(() => dbf.PlayersBridge.GetPlayers(team_id)
        is IEnumerable<PlayerDetails> pls
            ? Results.Ok(pls)
            : Results.NotFound()));

app.MapGet("/teams/{team_id}/transfers", async (uint team_id) =>
    await Task.Run(() => dbf.TransfersBridge.GetTransfers(team_id)
        is TransferHistory th
            ? Results.Ok(th)
            : Results.NotFound()));

app.MapGet("/matches/{match_id}/details", async (uint match_id) =>
    await Task.Run(() => dbf.MatchDetailsBridge.GetMatchDetails(match_id)
        is MatchDetails md
            ? Results.Ok(md)
            : Results.NotFound()));

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}