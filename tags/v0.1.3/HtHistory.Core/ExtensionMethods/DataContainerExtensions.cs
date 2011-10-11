using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.ExtensionMethods
{
    public static class DataContainerExtensions
    {
        public static bool IsActive(this Lineup.LineupRole role)
        {
            return !(
                role == Lineup.LineupRole.Captain ||
                role == Lineup.LineupRole.SetPiecesTaker ||
                role == Lineup.LineupRole.SubstitutionKeeper ||
                role == Lineup.LineupRole.SubstitutionKeeper_ ||
                role == Lineup.LineupRole.SubstitutionDefender ||
                role == Lineup.LineupRole.SubstitutionDefender_ ||
                role == Lineup.LineupRole.SubstitutionInnerMidfield ||
                role == Lineup.LineupRole.SubstitutionInnerMidfield_ ||
                role == Lineup.LineupRole.SubstitutionWinger ||
                role == Lineup.LineupRole.SubstitutionWinger_ ||
                role == Lineup.LineupRole.SubstitutionForward ||
                role == Lineup.LineupRole.SubstitutionForward_);
        }

    }
}
