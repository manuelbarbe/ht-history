using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataContainers
{


    public class MatchEvent
    {
        public enum MatchEventType
        {
            TacticalDisposition = 20,
            PlayerNamesInLineup = 21,
            YouthTeamPlayersFromNeighborhoodUsed = 22,
            RegionalDerby = 25,
            NeutralGround = 26,
            AwayIsActuallyHome = 27,
            SpectatorsVenueRain = 30,
            SpectatorsVenueCloudy = 31,
            SpectatorsVenueFairWeather = 32,
            SpectatorsVenueSunny = 33,
            Dominated = 40,
            BestPlayer = 41,
            WorstPlayer = 42,
            HalfTimeResult = 45,
            HatTrickComment = 46,
            NoTeamDominated = 47,
            PenaltyContestGoalByTechnical = 55,
            PenaltyContestGoalNoNerves = 56,
            PenaltyContestGoalInSpiteOfNerves = 57,
            PenaltyContestNoGoalBecauseOfNerves = 58,
            PenaltyContestNoGoalInSpiteOfNoNerves = 59,
            Underestimation = 60,
            OrganizationBreaks = 61,
            Withdraw = 62,
            RemoveUnderestimationAtPause = 63,
            Reorganize = 64,
            NervesInImportantThrillingGame = 65,
            RemoveUnderestimationAtPauseGoalDiff0 = 66,
            RemoveUnderestimationAtPauseGoalDiff1 = 67,
            SuccessfulPressing = 68,
            RemoveUnderestimation = 69,
            Extension = 70,
            PenaltyContestAfterExtension = 71,
            ExtensionDecided = 72,
            After22PenaltiesTossingCoin = 73,
            NewCaptain = 80,
            InjuredButKeepsPlaying = 90,
            ModeratelyInjuredLeavesField = 91,
            BadlyInjuredLeavesField = 92,
            InjuredAndNoReplacementExists = 93,
            InjuredAfterFoulButContinues = 94,
            InjuredAfterFoulAndExits = 95,
            InjuredAfterFoulAndNoReplacementExists = 96,
            KeeperInjuredFieldPlayerHasToTakeHisPlace = 97,


            /*
    100 	Reducing goal home team free kick
    101 	Reducing goal home team middle
    102 	Reducing goal home team left wing
    103 	Reducing goal home team right wing
    104 	Reducing goal home team penalty kick normal
    105 	SE: Goal Unpredictable long pass
    106 	SE: Goal Unpredictable scores on his own
    107 	SE: Goal longshot
    108 	SE: Goal Unpredictable special action
    109 	SE: Goal Unpredictable mistake
    110 	Equalizer goal home team free kick
    111 	Equalizer goal home team middle
    112 	Equalizer goal home team left wing
    113 	Equalizer goal home team right wing
    114 	Equalizer goal home team penalty kick normal
    115 	SE: Quick scores after rush
    116 	SE: Quick rushes, passes and reciever scores
    117 	SE: Tired defender mistake, striker scores
    118 	SE Goal: Corner to anyone
    119 	SE: Goal Corner: Head specialist
    120 	Goal to take lead home team free kick
    121 	Goal to take lead home team middle
    122 	Goal to take lead home team left wing
    123 	Goal to take lead home team right wing
    124 	Goal to take lead home team penalty kick normal
    125 	SE: Goal: Unpredictable, own goal
    130 	Increase goal home team free kick
    131 	Increase goal home team middle
    132 	Increase goal home team left wing
    133 	Increase goal home team right wing
    134 	Increase goal home team penalty kick normal
    135 	SE: Experienced forward scores
    136 	SE: Inexperienced defender causes goal
    137 	SE: Winger to Head spec. Scores
    138 	SE: Winger to anyone Scores
    139 	SE: Technical goes around head player
    140 	Counter attack goal, free kick
    141 	Counter attack goal, middle
    142 	Counter attack goal, left
    143 	Counter attack goal, right
    150 	Reducing goal away team free kick
    151 	Reducing goal away team middle
    152 	Reducing goal away team left wing
    153 	Reducing goal away team right wing
    154 	Reducing goal away team penalty kick normal
    160 	Equalizer goal away team free kick
    161 	Equalizer goal away team middle
    162 	Equalizer goal away team left wing
    163 	Equalizer goal away team right wing
    164 	Equalizer goal away team penalty kick normal
    170 	Goal to take lead away team free kick
    171 	Goal to take lead away team middle
    172 	Goal to take lead away team left wing
    173 	Goal to take lead away team right wing
    174 	Goal to take lead away team penalty kick normal
    180 	Increase goal away team free kick
    181 	Increase goal away team middle
    182 	Increase goal away team left wing
    183 	Increase goal away team right wing
    184 	Increase goal away team penalty kick normal
    185 	Goal indirect free kick
    186 	Counter attack goal, indirect free kick
    187 	Goal long shot
    200 	No reducing goal home team free kick
    201 	No reducing goal home team middle
    202 	No reducing goal home team left wing
    203 	No reducing goal home team right wing
    204 	No reducing goal home team penalty kick normal
    205 	SE: No Goal Unpredictable long pass
    206 	SE: No Goal Unpredictable almost scores
    207 	SE: No Goal longshot
    208 	SE: No Goal Unpredictable special action
    209 	SE: No Goal Unpredictable mistake
    210 	No equalizer goal home team free kick
    211 	No equalizer goal home team middle
    212 	No equalizer goal home team left wing
    213 	No equalizer goal home team right wing
    214 	No equalizer goal home team penalty kick normal
    215 	SE: Speedy misses after rush
    216 	SE: Quick rushes, passes but reciever fails
    217 	SE: Tired defender mistake but no goal
    218 	SE No goal: Corner to anyone
    219 	SE: No Goal Corner: Head specialist
    220 	No goal to take lead home team free kick
    221 	No goal to take lead home team middle
    222 	No goal to take lead home team left wing
    223 	No goal to take lead home team right wing
    224 	No goal to take lead home team penalty kick normal
    225 	SE: No goal: Unpredictable, own goal almost
    230 	No increase goal home team free kick
    231 	No increase goal home team middle
    232 	No increase goal home team left wing
    233 	No increase goal home team right wing
    234 	No increase goal home team penalty kick normal
    235 	SE: Experienced forward fails to score
    236 	SE: Inexperienced defender almost causes goal
    237 	SE: Winger to someone: No goal
    239 	SE: Technical goes around head player, no goal
    240 	Counter attack, no goal, free kick
    241 	Counter attack, no goal, middle
    242 	Counter attack, no goal, left
    243 	Counter attack, no goal, right
    250 	No reducing goal away team free kick
    251 	No reducing goal away team middle
    252 	No reducing goal away team left wing
    253 	No reducing goal away team right wing
    254 	No reducing goal away team penalty kick normal
    260 	No equalizer goal away team free kick
    261 	No equalizer goal away team middle
    262 	No equalizer goal away team left wing
    263 	No equalizer goal away team right wing
    264 	No equalizer goal away team penalty kick normal
    270 	No goal to take lead away team free kick
    271 	No goal to take lead away team middle
    272 	No goal to take lead away team left wing
    273 	No goal to take lead away team right wing
    274 	No goal to take lead away team penalty kick normal
    280 	No increase goal away team free kick
    281 	No increase goal away team middle
    282 	No increase goal away team left wing
    283 	No increase goal away team right wing
    284 	No increase goal away team penalty kick normal
    285 	No goal indirect free kick
    286 	Counter attack, no goal, indirect free kick
    287 	No goal long shot
    288 	No goal long shot, defended
    289 	SE: Quick rushes, stopped by quick defender
    301 	SE: Technical suffers from rain
    302 	SE: Powerful thrives in rain
    303 	SE: Technical thrives in sun
    304 	SE: Powerful suffers from sun
    305 	SE: Quick loses in rain
    306 	SE: Quick loses in sun
    331 	Tactic Type: Pressing
    332 	Tactic Type: Counter-attacking
    333 	Tactic Type: Attack in middle
    334 	Tactic Type: Attack on wings
    335 	Tactic Type: Play creatively
    336 	Tactic Type: Long shots
    343 	Tactic: Attack in middle used
    344 	Tactic: Attack on wings used
             */
             
            SubstitutionTeamIsBehind =  350,
            SubstitutionTeamIsAhead = 351,
            SubstitutionMinute = 352,

        /*
    360 	Change of tactic: team is behind
    361 	Change of tactic: team is ahead
    362 	Change of tactic: minute
    370 	Player position swap: team is behind
    371 	Player position swap: team is ahead
    372 	Player position swap: minute
    500 	Both teams walkover
    501 	Home team walkover
    502 	Away team walkover
    503 	Both teams break game (2 players remaining)
    504 	Home team breaks game (2 players remaining)
    505 	Away team breaks game (2 players remaining)
    510 	Yellow card nasty play
    511 	Yellow card cheating
             */
            RedCardSecondWarningNastyPlay = 512,
            RedCardSecondWarningCheating = 513,
            RedCardWithoutWarning = 514,
            MatchFinished = 599,
        }

        public MatchEvent(Match match, uint index, MatchEventType type, uint minute, string text, uint teamId, uint playerId, uint otherPlayerId)
        {
            if (match == null || text == null) throw new ArgumentNullException("match or text");

            Match = match;
            Index = index;
            Type = type;
            Minute = minute;
            Text = text;
            TeamId = teamId;
            PlayerId = playerId;
            OtherPlayerId = otherPlayerId;
        }

        public Match Match { get; set; }
        public uint Index { get; set; } 
        public MatchEventType Type { get; set; }
        public uint Minute { get; set; }
        public string Text { get; set; }
        public uint TeamId { get; set; }
        public uint PlayerId { get; set; }
        public uint OtherPlayerId { get; set; }
    }
}
