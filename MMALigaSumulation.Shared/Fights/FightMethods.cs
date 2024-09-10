using MMALigaSumulation.Shared.FightEngine.Comments;
using MMALigaSumulation.Shared.FightEngine.Constants;
using MMALigaSumulation.Shared.FightEngine.RoundUtils;
using MMALigaSumulation.Shared.FightEngine.Utils;

namespace MMALigaSumulation.Shared.Fights
{
    public static class FightMethods
    {

        public static void FightController(this Fight fight)
        {

            int fighterActive, fighterPassive, fighterAction1, fighterAction2, fighterAction;
            int timeInc;
            bool tempInTheClinch;
            bool fighter1OnTheGround, fighter2OnTheGround;
            bool f1Ground, f2Ground;

            timeInc = GetDeltaTime(fight);
            fight.CurrentTime += timeInc;

            if (!fight.NoTimeLimits && fight.CurrentTime >= fight.GetMinutesByRound(fight.CurrentRound) * 60 && !fight.Attributes.BoutFinished)
            {
                fight.Attributes.RoundFinished = true;

                if (fight.CurrentRound >= fight.GetMaxRounds())
                {
                    fight.Attributes.BoutFinished = true;
                    fight.Attributes.FinishedType = ReadTxts.ReadListToComment("Misc", FightConstants.TIMEOUT); 
                    fight.Attributes.FinishMode = FightConstants.RES_TIMEOUT;
                    fight.Attributes.FinishedDescription = ReadTxts.ReadListToComment("Misc", FightConstants.TIMEOUT);
                    RoundActions.FinishRound(fight);
                    RoundActions.JudgeFightRound(3, fight);

                    if (fight.Attributes.FighterWinner == -1 && fight.IsTournament)
                    {
                        RoundActions.TournamentTieExtraRound(fight);
                    }
                    else
                    {
                        RoundActions.FinishFight(fight.Attributes.FighterWinner, fight);
                    }

                    return;
                }
                else
                {
                    RoundActions.FinishRound(fight);
                    return;
                }
            }

        }

        public static void UpdateDamageDone(this Fight fight, int fighterIndex, double damage, bool clinch, bool ground)
        {

            if (!clinch && !ground)
            {
                fight.Statistics[fighterIndex].DamageDone += damage;
            }
            else if (clinch)
            {
                fight.IncreaseClinchDamage(damage, fighterIndex);
            }
            else if (ground)
            {
                fight.IncreaseGroundDamage(damage, fighterIndex);
            }
        }

        public static void UpdateDamageReceived(this Fight fight, int fighterIndex, double damage, bool clinch, bool ground)
        {
            if (!clinch && !ground)
            {
                fight.Statistics[fighterIndex].DamageReceived += damage;
            }
            else if (clinch)
            {
                fight.IncreaseRClinchDamage(damage, fighterIndex);
            }
            else if (ground)
            {
                fight.IncreaseRGroundDamage(damage, fighterIndex);
            }
        }

        public static void UpdateStatistic(this Fight fight, int fighterIndex, FightStatisticsTypes statType, int launched, int landed)
        {
            switch (statType)
            {
                case FightStatisticsTypes.stPunches:
                    fight.Statistics[fighterIndex].PunchesLaunched += launched;
                    fight.Statistics[fighterIndex].PunchesLanded += landed;
                    break;
                case FightStatisticsTypes.stKicks:
                    fight.Statistics[fighterIndex].KicksLaunched += launched;
                    fight.Statistics[fighterIndex].KicksLanded += landed;
                    break;
                case FightStatisticsTypes.stClinch:
                    fight.Statistics[fighterIndex].ClinchStrLaunches += launched;
                    fight.Statistics[fighterIndex].ClinchStrLanded += landed;
                    break;
                case FightStatisticsTypes.stGnP:
                    fight.Statistics[fighterIndex].GnPStrLaunched += launched;
                    fight.Statistics[fighterIndex].GnPStrLanded += landed;
                    break;
                case FightStatisticsTypes.stSubmission:
                    fight.Statistics[fighterIndex].SubmissionsAttemps += launched;
                    fight.Statistics[fighterIndex].SubmissionsAchieved += landed;
                    break;
                case FightStatisticsTypes.stTakedowns:
                    fight.Statistics[fighterIndex].TakedownsAttemps += launched;
                    fight.Statistics[fighterIndex].TakedownsAchieved += landed;
                    break;
                case FightStatisticsTypes.stGrappling:
                    fight.Statistics[fighterIndex].GrapplingAttemps += launched;
                    fight.Statistics[fighterIndex].GrapplingAchieved += landed;
                    break;
            }
        }

        public static void UpdateTimeOnGround(this Fight fight, int fighterIndex, int timeInc)
        {
            fight.Statistics[fighterIndex].TimeOnTheGround += timeInc;
        }

        private static void IncreaseClinchDamage(this Fight fight, double damage, int fighterIndex)
        {
            fight.Statistics[fighterIndex].DamageClinch += damage;
            fight.Statistics[fighterIndex].DamageDone += damage;
        }

        private static void IncreaseGroundDamage(this Fight fight, double damage, int fighterIndex)
        {
            fight.Statistics[fighterIndex].DamageGround += damage;
            fight.Statistics[fighterIndex].DamageDone += damage;
        }

        private static void IncreaseRClinchDamage(this Fight fight, double damage, int fighterIndex)
        {
            fight.Statistics[fighterIndex].TempDamageClinch += damage;
            fight.Statistics[fighterIndex].DamageRClinch += damage;
            fight.Statistics[fighterIndex].DamageReceived += damage;
        }

        private static void IncreaseRGroundDamage(this Fight fight, double damage, int fighterIndex)
        {
            fight.Statistics[fighterIndex].TempDamageGround += damage;
            fight.Statistics[fighterIndex].DamageRGround += damage;
            fight.Statistics[fighterIndex].DamageReceived += damage;
        }

        private static int GetDeltaTime(Fight fight)
        {
            int timeAdvance = TweakingConstants.TIMEADVANCE;
            int fixedRandom = RandomUtils.GetFixedRandom(timeAdvance);
            int rushTotal = (fight.Fighters[0].FightAttributes.Rush + fight.Fighters[1].FightAttributes.Rush) / 2;
            int result = fixedRandom - rushTotal;

            return Math.Max(result, 1);
        }

        public static int GetMaxRounds(this Fight fight)
        {
            return fight.NumberRounds > 0 ? fight.NumberRounds : 5;
        }

        public static int GetMinutesByRound(this Fight fight, int round)
        {
            return round == 1 ? fight.GetMinutesFirstRound() : fight.GetMinutesOtherRounds();
        }

        private static int GetMinutesFirstRound(this Fight fight)
        {
            return fight.MinsForRound > 0 ? fight.MinsForRound : 5;
        }

        private static int GetMinutesOtherRounds(this Fight fight)
        {
            return fight.MinsForRound > 0 ? fight.MinsForRound : 5;
        }

        public static bool GetNoTimeLimits(this Fight fight)
        {
            return fight.NoTimeLimits || true;
        }

    }
}
