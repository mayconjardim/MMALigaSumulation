using MMALigaSumulation.Shared.FightEngine.Constants;
using MMALigaSumulation.Shared.FightEngine.Utils;
using MMALigaSumulation.Shared.Fighters;
using MMALigaSumulation.Shared.Fights;

namespace MMALigaSumulation.Shared.FightEngine.Comments
{
    public static class Comments
    {


        public static void DoComment(Fighter act, Fighter pas, string comment, Fight fight, List<string> PBP)
        {
            comment = ReplaceTokens(act, pas, comment, fight);
            PBP.Add(comment);
        }

        public static string ReplaceTokens(Fighter act, Fighter pas, string comment, Fight fight)
        {

            comment = comment.Replace("%site", FightConstants.CAGE);

            comment = comment.Replace("%HoldSite", FightConstants.FENCE);
            comment = comment.Replace("%holdSite", FightConstants.FENCE);

            comment = comment.Replace("%movename", fight.Attributes.MoveName);

            comment = comment.Replace("%a1", act.Name());
            comment = comment.Replace("%a2", act.NickName);
            comment = comment.Replace("%d1", pas.Name());
            comment = comment.Replace("%d2", pas.NickName);

            comment = comment.Replace("%ref", "Herb Dean");

            comment = comment.Replace("[SIDE]", fight.Attributes.Side);

            comment = comment.Replace("%location", fight.Attributes.Location);

            if (fight.Attributes.FinishMode == FightConstants.RES_TIMEOUT)
            {
                comment = comment.Replace("%method", fight.Attributes.FinishedType);
            }
            else
            {
                comment = comment.Replace("%method", $"{fight.Attributes.FinishedType} ({fight.Attributes.FinishedDescription})");
            }

            comment = comment.Replace("%time_and_round", $"{TimeUtils.GetTime(fight.CurrentTime)} Round {fight.CurrentRound}");

            comment = comment.Replace("%time", TimeUtils.GetTime(fight.CurrentTime));

            comment = comment.Replace("%round", fight.CurrentRound.ToString());

            comment = comment.Replace("%organization", "MMALiga");

           
            comment = comment.Replace("%venue", "venue");

            return comment;
        }

    }
}
