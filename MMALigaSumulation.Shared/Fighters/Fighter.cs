namespace MMALigaSumulation.Shared.Fighters
{
    public class Fighter
    {

        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string NickName { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; } 
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }
        public int WeightClassId { get; set; }
        public double Weight { get; set; }
        public double Reach { get; set; }
        public int Version { get; set; }
        public bool Retired { get; set; }
        public int CareerStatus { get; set; }

        public required FighterAttributes Attributes { get; set; }
        public required FighterStrategies Strategies { get; set; }
        public required FighterStyles Styles { get; set; }


    }
}
