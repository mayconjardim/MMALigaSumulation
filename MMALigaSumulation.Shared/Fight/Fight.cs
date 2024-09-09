using MMALigaSumulation.Shared.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMALigaSumulation.Shared.Fight
{
    internal class Fight
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
        public Statistic[] Statistics { get; set; } = new Statistic[2];
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

        // Substitui os padrões da organização
        public int NumberRounds { get; set; }
        public bool NoTimeLimits { get; set; }
        public int MinsForRound { get; set; }
        public bool Catchweight { get; set; }

        // Campeão antes de começar a luta (se houver)
        public string CurrentChampion { get; set; } = string.Empty;

    }
}
