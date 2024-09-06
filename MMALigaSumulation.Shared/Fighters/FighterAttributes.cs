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

        public double Ranking()
        {

            Random random = new Random();
            int number = random.Next(1, 6);

            double statsRanking = Punching + Kicking + ClinchStriking + Takedowns + ClinchGrappling + Aggressiveness
                    + Control + Motivation + Dodging + TakedownsDef + SubDefense + Strength + Toughness + Agility
                    + KOResistance + Conditioning + GroundGame + Submission + GnP / 19;

            statsRanking += number;
            return statsRanking;
        }

        public double InitiativeBonus(int Rush)
        {
            double result = (Agility / 4) + (Aggressiveness / 6) + Rush;
            result = result * 100 / 100;
            return result;
        }

        public double Mean()
        {
            double result = (DefenseMean() + FitnessMean() + GroundMean() + MentalMean() + StrikingMean())
                    / 5;
            return result;
        }

        public double ClinchMean()
        {
            return (ClinchStriking + ClinchGrappling) / 2;
        }

        public double GroundMean()
        {
            double result = (GroundGame + Submission + GnP) * 100 / 60;
            return result;
        }

        public double MentalMean()
        {
            double result = (Aggressiveness + Control + Motivation) * 100 / 60;
            return result;
        }

        public double StrikingMean()
        {
            double result = (Punching + Kicking + ClinchStriking + ClinchGrappling + Takedowns)
                    * 100 / 100;
            return result;
        }

        public double FitnessMean()
        {
            double result = Strength + Toughness + Agility + KOResistance + Conditioning;
            return result;
        }

        public double DefenseMean()
        {
            double result = (Dodging + TakedownsDef + SubDefense) * 100 / 60;
            return result;
        }

        public double AttackBonus(FighterFightAttributes attributes)
        {
            double bonus = attributes.Accuracy + (Agility / 4) + (Aggressiveness / 5) - attributes.DirtyMoveMalus;
            return bonus;
        }

        public double DefenseBonus(FighterFightAttributes attributes)
        {
            double DAZED_MALUS = 7;
            double bonus = attributes.Defense + (Agility / 4) + (Control / 5) - (Aggressiveness / 6) - attributes.DirtyMoveMalus;
            if (attributes.Dazed)
            {
                bonus -= DAZED_MALUS;
            }
            return bonus;
        }

        public double DamageBonus(FighterFightAttributes attributes)
        {
            double result = (Strength / 2) + attributes.DamageMod + Math.Round(Aggressiveness / 8) - attributes.DirtyMoveMalus + attributes.AggPower;

            result = Math.Max(1, Math.Min(100, result));

            return result;
        }

        public double GetKoResistance(FighterModifiers attributes)
        {
            return KOResistance + attributes.KOResistanceMod;
        }

    }

}
