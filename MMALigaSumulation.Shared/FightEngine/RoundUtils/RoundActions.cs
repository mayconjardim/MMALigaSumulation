using MMALigaSumulation.Shared.Fights;

namespace MMALigaSumulation.Shared.FightEngine.RoundUtils
{
    public static class RoundActions
    {

        public static void FinishRound(Fight fight)
        {

            string endRoundComment = applicationUtils.EndRoundComment();
            DoComment(fight.Fighters[0], fight.Fighters[1], endRoundComment);
            MakeEndRoundComment();

            if (!fight.Attributes.BoutFinished)
            {
                BetweenRoundComments();
            }

        }

    }
}
