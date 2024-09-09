using MMALigaSumulation.Shared.Fighters;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMALigaSumulation.Shared.Fight
{
    public class Fight
    {

        public required Fighter FighterOne { get; set; }
        public required Fighter FighterTwo { get; set; }
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
        public string PBPJson { get; set; } = string.Empty;
        public bool OneSided { get; set; }
        public int NumberRounds { get; set; } 
        public bool NoTimeLimits { get; set; }
        public int MinsForRound { get; set; }
        public bool Catchweight { get; set; }
        public string CurrentChampion { get; set; } = string.Empty;

        //Atributos da Luta (Não armazenam no banco).
        [NotMapped]
        public FightAttributes? Attributes { get; set; }

        [NotMapped]
        public FightStatistic[]? Statistics { get; set; }

        [NotMapped]
        public List<string>? PBP { get; set; }

        [NotMapped]
        public Fighter[]? Fighters { get; set; }

        //Luta
        public void FightSim()
        {

            //Inicia Atributos da Luta
            FightAttributes atributtes = new FightAttributes();
            FightStatistic statistic = new FightStatistic();
            PBP = new List<string>();
            Fighters = [FighterOne, FighterTwo];
        }

    }
}
