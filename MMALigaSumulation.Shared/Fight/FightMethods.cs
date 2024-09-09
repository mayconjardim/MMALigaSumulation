namespace MMALigaSumulation.Shared.Fight
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

            timeInc = GetDeltaTime();

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

        private static int GetDeltaTime(this Fight fight)
        {
            int timeAdvance = ApplicationUtils.TIMEADVANCE;
            int fixedRandom = ApplicationUtils.GetFixedRandom(timeAdvance);
            int rushTotal = (fight.Fighters[0].FightAttributes.Rush + fight.Fighters[1].FightAttributes.Rush) / 2;
            int result = fixedRandom - rushTotal;

            return Math.Max(result, 1);
        }

    }
}
