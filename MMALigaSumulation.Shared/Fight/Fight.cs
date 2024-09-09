using MMALigaSumulation.Shared.Fighters;

namespace MMALigaSumulation.Shared.Fight
{
    public class Fight
    {

        public Fighter[] Fighters { get; set; } = new Fighter[2];
        public int Winner { get; set; }
        public Referee Referee { get; set; }
        public int CurrentRound { get; set; }
        public int CurrentTime { get; set; }
        public FightHype FightHype { get; set; }
        public double FightQuality { get; set; }
        public double FightQualityBonus { get; set; }
        public string FightResult { get; set; } = string.Empty;
        public string FightResultType { get; set; } = string.Empty;
        public bool TitleBout { get; set; }
        public string StatisticsJson { get; set; } = string.Empty;
        public bool IsMainEvent { get; set; }
        public bool IsCoMainEvent { get; set; }
        public bool IsPrelimEvent { get; set; }
        public bool IsMainCard { get; set; }
        public bool IsTournament { get; set; }
        public bool IsTournamentChecked { get; set; }
        public string EventName { get; set; } = string.Empty;
        public List<string> PBP { get; set; } = new List<string>();
        public string PBPJson { get; set; } = string.Empty;
        public bool OneSided { get; set; }
        public int NumberRounds { get; set; } 
        public bool NoTimeLimits { get; set; }
        public int MinsForRound { get; set; }
        public bool Catchweight { get; set; }
        public string CurrentChampion { get; set; } = string.Empty;

        //Atributos da Luta (Não armazenam no banco).
        public FightStatistic[] Statistics { get; set; } = new FightStatistic[2];

        //Metodos necessarios para a luta
        public void UpdateDamageDone(int fighterIndex, double damage, bool clinch, bool ground)
        {
            if (!clinch && !ground)
            {
                Statistics[fighterIndex].DamageDone += damage;
            }
            else if (clinch)
            {
                IncreaseClinchDamage(damage, fighterIndex);
            }
            else if (ground)
            {
                IncreaseGroundDamage(damage, fighterIndex);
            }
        }

        public void UpdateDamageReceived(int fighterIndex, double damage, bool clinch, bool ground)
        {
            if (!clinch && !ground)
            {
                Statistics[fighterIndex].DamageReceived += damage;
            }
            else if (clinch)
            {
                IncreaseRClinchDamage(damage, fighterIndex);
            }
            else if (ground)
            {
                IncreaseRGroundDamage(damage, fighterIndex);
            }
        }

        public void UpdateStatistic(int fighterIndex, FightStatisticsTypes statType, int launched, int landed)
        {
            switch (statType)
            {
                case FightStatisticsTypes.stPunches:
                    Statistics[fighterIndex].PunchesLaunched += launched;
                    Statistics[fighterIndex].PunchesLanded += landed;
                    break;
                case FightStatisticsTypes.stKicks:
                    Statistics[fighterIndex].KicksLaunched += launched;
                    Statistics[fighterIndex].KicksLanded += landed;
                    break;
                case FightStatisticsTypes.stClinch:
                    Statistics[fighterIndex].ClinchStrLaunches += launched;
                    Statistics[fighterIndex].ClinchStrLanded += landed;
                    break;
                case FightStatisticsTypes.stGnP:
                    Statistics[fighterIndex].GnPStrLaunched += launched;
                    Statistics[fighterIndex].GnPStrLanded += landed;
                    break;
                case FightStatisticsTypes.stSubmission:
                    Statistics[fighterIndex].SubmissionsAttemps += launched;
                    Statistics[fighterIndex].SubmissionsAchieved += landed;
                    break;
                case FightStatisticsTypes.stTakedowns:
                    Statistics[fighterIndex].TakedownsAttemps += launched;
                    Statistics[fighterIndex].TakedownsAchieved += landed;
                    break;
                case FightStatisticsTypes.stGrappling:
                    Statistics[fighterIndex].GrapplingAttemps += launched;
                    Statistics[fighterIndex].GrapplingAchieved += landed;
                    break;
            }
        }

        public void UpdateTimeOnGround(int fighterIndex, int timeInc)
        {
            Statistics[fighterIndex].TimeOnTheGround += timeInc;
        }

        private void IncreaseClinchDamage(double damage, int fighterIndex)
        {
            Statistics[fighterIndex].DamageClinch += damage;
            Statistics[fighterIndex].DamageDone += damage;
        }

        private void IncreaseGroundDamage(double damage, int fighterIndex)
        {
            Statistics[fighterIndex].DamageGround += damage;
            Statistics[fighterIndex].DamageDone += damage;
        }

        private void IncreaseRClinchDamage(double damage, int fighterIndex)
        {
            Statistics[fighterIndex].TempDamageClinch += damage;
            Statistics[fighterIndex].DamageRClinch += damage;
            Statistics[fighterIndex].DamageReceived += damage;
        }

        private void IncreaseRGroundDamage(double damage, int fighterIndex)
        {
            Statistics[fighterIndex].TempDamageGround += damage;
            Statistics[fighterIndex].DamageRGround += damage;
            Statistics[fighterIndex].DamageReceived += damage;
        }

    }
}
