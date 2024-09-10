namespace MMALigaSumulation.Shared.Fighters
{
    public class FighterFightAttributes
    {



        public int PainAndTiredness { get; set; }
        public int FearManagement { get; set; }
        public int FightSpirit { get; set; }
        public int FightPerformance { get; set; }
        public int LatestResults { get; set; }

        public double FaceInjury { get; set; }
        public double LeftArmInjury { get; set; }
        public double RightArmInjury { get; set; }
        public double BackInjury { get; set; }
        public double RightLegInjury { get; set; }
        public double LeftLegInjury { get; set; }
        public double TorsoInjury { get; set; }

        public double DamageMod { get; set; }
        public double InitMod { get; set; }
        public double AggPower { get; set; }
        public double Defense { get; set; }
        public int CareerStatus { get; set; }
        public double CurrentHP { get; set; }
        public double CurrentStamina { get; set; }
        public double StaminaLoss { get; set; }
        public double Accuracy { get; set; }
        public bool OnTheGround { get; set; }
        public bool Dazed { get; set; }
        public bool UseElbows { get; set; }
        public long DirtyMoveMalus { get; set; }
        public int Rush { get; set; }
        public int ActionsInGround { get; set; }
        public int ActionsInClinch { get; set; }
        public int ActionsInStandUp { get; set; }
        public double TempDamageGround { get; set; }
        public double TempDamageClinch { get; set; }
        public int RoundsInTheGround { get; set; }
        public double TrainingStatus { get; set; }
        public int InjuryResistance { get; set; }
        public int CutResistance { get; set; }
        public int Cuts { get; set; }
        public double Moral { get; set; }

        // Pontuacão
        public int[] RoundStandUpPoints { get; set; } = new int[10];
        public int[] RoundGroundPoints { get; set; } = new int[10];
        public int[] RoundAggPoints { get; set; } = new int[10];
        public int[] RoundTechPoints { get; set; } = new int[10];
        public int[] PointsPenalization { get; set; } = new int[10];

        // Lesões
        public List<string> Injury = new List<string>();

        public FighterFightAttributes()
        {
       
            PainAndTiredness = 0;
            FearManagement = 0;
            FightSpirit = 0;
            FightPerformance = 0;
            LatestResults = 0;

            FaceInjury = 0.0;
            LeftArmInjury = 0.0;
            RightArmInjury = 0.0;
            BackInjury = 0.0;
            RightLegInjury = 0.0;
            LeftLegInjury = 0.0;
            TorsoInjury = 0.0;

            AggPower = 0.0;
            Defense = 0.0;
            CareerStatus = 2;
            CurrentHP = 0.0;
            CurrentStamina = 0.0;
            StaminaLoss = 0.0;
            Accuracy = 0.0;
            OnTheGround = false;
            Dazed = false;
            UseElbows = false;
            DirtyMoveMalus = 0L;
            Rush = 0;
            ActionsInGround = 0;
            ActionsInClinch = 0;
            ActionsInStandUp = 0;
            TempDamageGround = 0.0;
            TempDamageClinch = 0.0;
            RoundsInTheGround = 0;
            TrainingStatus = 0.0;
            InjuryResistance = 0;
            CutResistance = 0;
            Cuts = 0;
            Moral = 0.0;
        }

        public void ClearRoundPoints(int nRound)
        {
            RoundStandUpPoints[nRound] = 0;
            RoundGroundPoints[nRound] = 0;
            RoundAggPoints[nRound] = 0;
            RoundTechPoints[nRound] = 0;
        }

        public void ClearAllRoundPoints()
        {
            for (int i = 1; i <= 5; i++)
            {
                ClearRoundPoints(i);
            }
        }

        public int IncreasePoints(int NRound, int Points, bool standing = true)
        {
            int result = 0;
            if (NRound <= 10)
            {
                if (standing)
                {
                    RoundStandUpPoints[NRound - 1] += Points;
                    result = RoundStandUpPoints[NRound - 1];
                }
                else
                {
                    RoundGroundPoints[NRound - 1] += Points;
                    result = RoundGroundPoints[NRound - 1];
                }
            }
            return result;
        }

        public int GetRoundPoints(int round)
        {
            if (round <= 0 || round >= RoundAggPoints.Length)
            {
                return 0;
            }

            int result = 0;
            result += RoundAggPoints[round];
            result += RoundTechPoints[round];
            result += RoundStandUpPoints[round];
            result += RoundGroundPoints[round];

            return result;
        }

        public int TotalPoints()
        {
            int result = 0;

            for (int index = 0; index < 10; index++)
            {
                result += RoundAggPoints[index];
                result += RoundTechPoints[index];
                result += RoundGroundPoints[index];
                result += RoundStandUpPoints[index];
            }

            return result;
        }

        public bool CheckDirtyMove(double Aggressiveness, int DirtyFighting)
        {
            const int MAX_RANDOM = 120;
            int modifiers = 0;

            if (CurrentHP < 50)
            {
                modifiers += 1;
            }
            else if (CurrentHP < 20)
            {
                modifiers += 2;
            }

            if (CurrentStamina < 50)
            {
                modifiers += 1;
            }
            else if (CurrentStamina < 20)
            {
                modifiers += 2;
            }

            modifiers += (int)Math.Round(Aggressiveness / 7.0);

            modifiers *= DirtyFighting;

            return (new Random().NextDouble() * MAX_RANDOM <= modifiers);
        }

        public void AddInjuryToList(string injuryName)
        {
            if (Injury == null)
            {
                Injury = new List<string>();
            }

            if (!Injury.Contains(injuryName))
            {
                Injury.Add(injuryName);
            }
        }


    }

}
