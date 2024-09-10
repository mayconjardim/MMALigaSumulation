namespace MMALigaSumulation.Shared.Fights
{
    public class FightAttributes
    {

        public int CounterProb { get; set; }
        public int InjuryProb { get; set; }
        public int CutProb { get; set; }
        public bool IsCounter { get; set; }
        public bool IsLockingASub { get; set; }
        public int FighterHolding { get; set; }
        public int CounterMove1 { get; set; }
        public int CounterMove2 { get; set; }
        public int NumHits { get; set; }
        public int HitsLanded { get; set; }
        public int KOSubProb { get; set; }
        public string FullComment { get; set; } = string.Empty;
        public string SuccessfulSubComment { get; set; } = string.Empty;
        public int HitLocation { get; set; }
        public int SubLocation { get; set; }
        public int Position { get; set; }
        public bool InTheClinch { get; set; }
        public int FighterOnTop { get; set; }
        public int GuardType { get; set; }
        public string MoveName { get; set; } = string.Empty;
        public int FighterLockingSub { get; set; }
        public int NumHooks { get; set; }
        public string Side { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool BoutFinished { get; set; }
        public bool RoundFinished { get; set; }
        public string FinishedType { get; set; } = string.Empty;
        public string FinishedDescription { get; set; } = string.Empty;
        public int FinishMode { get; set; }
        public int FighterWinner { get; set; }

    }
}
