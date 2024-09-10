using MMALigaSumulation.Shared.FightEngine.Comments;
using MMALigaSumulation.Shared.FightEngine.Constants;
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

        public static void JudgeFightRound(int numberJudges, Fight fight)
        {
            int winsFighter1 = 0;
            int winsFighter2 = 0;

            for (int index = 1; index <= numberJudges; index++)
            {
                var judgeResult = judge.JudgeFightRoundWise(fight.Fighters[0], fight.Fighters[1], fight.CurrentRound);

                if (judgeResult.Winner == 0)
                {
                    winsFighter1++;
                }
                else if (judgeResult.Winner == 1)
                {
                    winsFighter2++;
                }
            }

            if (winsFighter1 > winsFighter2)
            {
                DetermineFighterOutcome(winsFighter1, winsFighter2, 0, fight);
            }
            else if (winsFighter2 > winsFighter1)
            {
                DetermineFighterOutcome(winsFighter2, winsFighter1, 1, fight);
            }
            else
            {
                fight.Attributes.FighterWinner = -1;
                fight.Attributes.FinishedType = ReadTxts.ReadListToComment("Misc", FightConstants.DRAW);
            }
        }

        private static void DetermineFighterOutcome(int winnerWins, int loserWins, int winner, Fight fight)
        {

            if (winnerWins == 3 && loserWins == 0)
            {
                fight.Attributes.FighterWinner = winner;
                fight.Attributes.FinishedType = fight.Attributes.FinishedDescription = ReadTxts.ReadListToComment("Misc", FightConstants.DECISION);
            }
            else if (winnerWins == 2 && loserWins == 1)
            {
                fight.Attributes.FighterWinner = winner;
                fight.Attributes.FinishedType = fight.Attributes.FinishedDescription =  ReadTxts.ReadListToComment("Misc", FightConstants.SPLIT_DECISION);
            }
            else if (winnerWins == 2 && loserWins == 0)
            {
                fight.Attributes.FighterWinner = winner;
                fight.Attributes.FinishedType = fight.Attributes.FinishedDescription = ReadTxts.ReadListToComment("Misc", FightConstants.MAJORITY_DECISION);
            }
            else if (winnerWins == 1 && loserWins == 0)
            {
                fight.Attributes.FighterWinner = -1;
                fight.Attributes.FinishedType = fight.Attributes.FinishedDescription = ReadTxts.ReadListToComment("Misc", FightConstants.MAJORITY_DRAW);
            }

        }

    }
}
