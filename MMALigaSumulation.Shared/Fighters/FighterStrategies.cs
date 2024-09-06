namespace MMALigaSumulation.Shared.Fighters
{
    public class FighterStrategies
    {

        // Geral
        public int Punching { get; set; }
        public int Kicking { get; set; }
        public int Takedowns { get; set; }
        public int Clinching { get; set; }

        // Clinch
        public int DirtyBoxing { get; set; }
        public int ThaiClinch { get; set; }
        public int ClinchTakedowns { get; set; }
        public int AvoidClinching { get; set; }

        // Grappling
        public int GroundnPound { get; set; }
        public int Submission { get; set; }
        public int Positioning { get; set; }
        public int StandUp { get; set; }
        public int LaynPray { get; set; }

    }
}
