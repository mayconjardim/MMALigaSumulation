using MMALigaSumulation.Shared.FightEngine.Comments;
using MMALigaSumulation.Shared.FightEngine.Constants;
using MMALigaSumulation.Shared.Fights;

namespace MMALigaSumulation.Shared.FightEngine.RoundUtils
{
    public static class RoundActions
    {

        public static void FinishFight(int winner, Fight fight)
        {
            fight.Attributes.BoutFinished = true;

            // Ajusta o tempo atual se ultrapassar o limite por round
            if (fight.CurrentTime > fight.GetMinutesByRound(fight.CurrentRound) * 60 && !fight.NoTimeLimits)
            {
                fight.CurrentTime = fight.GetMinutesByRound(fight.CurrentRound) * 60;
            }

            fight.Winner = winner;
            int loser;
            string winningSentence;

            if (winner != -1)
            {
                loser = winner == 1 ? 0 : 1;
                winningSentence = Comment.ReturnComment(ReadTxts.ReadFileToList("Winner"));
            }
            else
            {
                winner = 0; 
                loser = 1;
                winningSentence = Comment.ReturnComment(ReadTxts.ReadFileToList("ResDraw"));
            }

            Comment.DoComment(fight.Fighters[winner], fight.Fighters[loser], winningSentence, fight, fight.PBP);

            //FightHistory.Add(fight);
            ColorComments.MakeUpsetComment(fight.Fighters[winner], fight.Fighters[loser], fight);
            //CheckChampion(fight.Fighters[winner], fight.Fighters[loser]);

            fight.FightResult = Comment.ReplaceTokens(fight.Fighters[winner], fight.Fighters[loser], winningSentence, fight);
            fight.FightResultType = fight.Attributes.FinishedType;
            fight.Fighters[0] = fight.Fighters[0];
            fight.Fighters[1] = fight.Fighters[1];

        }

        public static void FinishRound(Fight fight)
        {

            string endRoundComment = Comment.ReturnComment(ReadTxts.ReadFileToList("EndRound"));
            Comment.DoComment(fight.Fighters[0], fight.Fighters[1], endRoundComment, fight, fight.PBP);
            ColorComments.MakeEndRoundComment(fight);

            if (!fight.Attributes.BoutFinished)
            {
                ColorComments.BetweenRoundComments(fight);
            }

        }

        public static void JudgeFightRound(int numberJudges, Fight fight)
        {
            int winsFighter1 = 0;
            int winsFighter2 = 0;

            for (int index = 1; index <= numberJudges; index++)
            {
                var judgeResult = JudgeActions.JudgeFightRoundWise(fight.Fighters[0], fight.Fighters[1], fight.CurrentRound);

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

        public static void TournamentTieExtraRound(Fight fight)
        {
       
            fight.Attributes.FinishedType = "N/A";
            fight.Attributes.FinishMode = -1;
            fight.NumberRounds = fight.GetMaxRounds() + 1;
            fight.Attributes.BoutFinished = false;
        }


    }
}
