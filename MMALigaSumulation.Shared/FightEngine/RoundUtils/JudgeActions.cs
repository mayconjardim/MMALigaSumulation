﻿using MMALigaSumulation.Shared.Fighters;

namespace MMALigaSumulation.Shared.FightEngine.RoundUtils
{
    public static class JudgeActions
    {

        public JudgePerRound JudgeFightRoundWise(Fighter fighter1, Fighter fighter2, int rounds)
        {
            int[] pointsFighter1 = new int[rounds];
            int[] pointsFighter2 = new int[rounds];
            int totalFighter1 = 0;
            int totalFighter2 = 0;

            JudgePerRound result = new JudgePerRound();

            // Calcula os pontos para cada round
            for (int index = 0; index < rounds; index++)
            {
                totalFighter1 = CalculateTotalPoints(fighter1, index);
                totalFighter2 = CalculateTotalPoints(fighter2, index);

                int total = totalFighter1 + totalFighter2;
                int criteria = appUtils.GetBalancedRandom(total) + 1;

                if (criteria < totalFighter1)
                {
                    pointsFighter1[index] = 10 - fighter1.PointsPenalization[index];
                    pointsFighter2[index] = (totalFighter1 > totalFighter2 * appUtils.EightPointsCriteria)
                        ? 8 - fighter2.PointsPenalization[index]
                        : 9 - fighter2.PointsPenalization[index];
                }
                else
                {
                    pointsFighter2[index] = 10 - fighter2.PointsPenalization[index];
                    pointsFighter1[index] = (totalFighter1 > totalFighter1 * appUtils.EightPointsCriteria)
                        ? 8 - fighter1.PointsPenalization[index]
                        : 9 - fighter1.PointsPenalization[index];
                }
            }

            // Resolve a decisão
            result.Points1 = CalculateRoundPoints(pointsFighter1, rounds, out totalFighter1);
            result.Points2 = CalculateRoundPoints(pointsFighter2, rounds, out totalFighter2);

            // Determina o vencedor
            result.Winner = DetermineWinner(totalFighter1, totalFighter2);

            return result;
        }

        private int CalculateTotalPoints(Fighter fighter, int roundIndex)
        {
            return fighter.RoundStandUpPoints[roundIndex] * organization.JudgesStrikingImportance +
                   fighter.RoundGroundPoints[roundIndex] * organization.JudgesGroundImportance +
                   fighter.RoundAggPoints[roundIndex] * organization.JudgesAggressivenessImportance +
                   fighter.RoundTechPoints[roundIndex] * organization.JudgesTechnicalImportance;
        }

        private string CalculateRoundPoints(int[] points, int rounds, out int totalPoints)
        {
            totalPoints = 0;
            string roundPoints = string.Empty;
            for (int index = 0; index < rounds; index++)
            {
                totalPoints += points[index];
                roundPoints += $" {points[index]}";
            }
            return roundPoints + $": {totalPoints}";
        }

        private int DetermineWinner(int totalFighter1, int totalFighter2)
        {
            if (totalFighter1 > totalFighter2)
            {
                return 0;
            }
            else if (totalFighter2 > totalFighter1)
            {
                return 1;
            }
            return -1;
        }

    }
}
