using MMALigaSumulation.Shared.FightEngine.RoundUtils;
using MMALigaSumulation.Shared.FightEngine.Utils;
using MMALigaSumulation.Shared.Fighters;
using MMALigaSumulation.Shared.Fights;

namespace MMALigaSumulation.Shared.FightEngine.Comments
{
    public class ColorComments
    {

        public static void MakeUpsetComment(Fighter act, Fighter pas, Fight fight)
        {

            double UpsetLimit = 0.85;

            double r = act.Attributes.Ranking() / pas.Attributes.Ranking();
            if (r <= UpsetLimit)
            {
                string upsetComment = Comment.ReturnComment(ReadTxts.ReadFileToList("Upset"));
                Comment.DoComment(act, pas, upsetComment, fight, fight.PBP);
            }
        }

        public static void MakeEndRoundComment(Fight fight)
        {

            double WINNER1_DIFF = 1.25;

            var jpr = JudgeActions.JudgeFightRoundWise(fight.Fighters[0], fight.Fighters[1], fight.CurrentRound);
            int roundWinner = jpr.Winner;
            int roundLoser = (roundWinner == 1) ? 0 : 1;

            double diff;

            if (fight.Fighters[1].FightAttributes.GetRoundPoints(fight.CurrentRound) + 1 > 0)
            {
                diff = fight.Fighters[0].FightAttributes.GetRoundPoints(fight.CurrentRound) / (fight.Fighters[1].FightAttributes.GetRoundPoints(fight.CurrentRound) + 1);
            }
            else
            {
                diff = 2;
            }

            string endRoundComment;

            if (diff >= WINNER1_DIFF)
            {
                endRoundComment = Comment.ReturnComment(ReadTxts.ReadFileToList("EndRoundWinner"));
            }
            else
            {
                endRoundComment = Comment.ReturnComment(ReadTxts.ReadFileToList("EndRoundClose"));
            }

            Comment.DoComment(fight.Fighters[roundWinner], fight.Fighters[roundLoser], endRoundComment, fight, fight.PBP);
        }

        public static void MakeCutmanComment(Fighter act, Fighter pas, Fight fight)
        {
            string comment = Comment.ReturnComment(ReadTxts.ReadFileToList("Cutman"));
            Comment.DoComment(act, pas, comment, fight, fight.PBP);
        }

        public static void BetweenRoundComments(Fight fight)
        {

            if (RandomUtils.GetSRandom() < fight.Fighters[0].FightAttributes.Cuts)
            {
                MakeCutmanComment(fight.Fighters[0], fight.Fighters[1], fight);
            }

            if (RandomUtils.GetSRandom() < fight.Fighters[1].FightAttributes.Cuts)
            {
                MakeCutmanComment(fight.Fighters[1], fight.Fighters[0], fight);
            }

        }

    }
}
