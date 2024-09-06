namespace MMALigaSumulation.Shared.Fighters
{
    public class FighterAttributes
    {

        // Fisicos
        public double Strength { get; set; }
        public double Agility { get; set; }
        public double Conditioning { get; set; }
        public double KOResistance { get; set; }
        public double Toughness { get; set; }

        // Trocação
        public double Punching { get; set; }
        public double Kicking { get; set; }
        public double ClinchStriking { get; set; }
        public double ClinchGrappling { get; set; }
        public double Takedowns { get; set; }

        // Grappling
        public double GnP { get; set; } // Ground and Pound
        public double Submission { get; set; }
        public double GroundGame { get; set; }

        // Mentais
        public double Aggressiveness { get; set; }
        public double Control { get; set; }
        public double Motivation { get; set; }

        // Defesa
        public double Dodging { get; set; }
        public double SubDefense { get; set; } // Submission Defesa
        public double TakedownsDef { get; set; } // Takedown Defesa

    }

}
