using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatsDefenceBST.BSTree
{
    internal class DSNode
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public DSNode Left { get; set; } = null;
        public DSNode Right { get; set; } = null;

        public DSNode(int min, int max, List<string> defenses)
        {
            MinSeverity = min;
            MaxSeverity = max;
            Defenses = defenses;
        }

        public bool IsInRange(int severity) => MinSeverity <= severity && severity <= MaxSeverity;
        public bool IsAboveRange(int severity) => severity > MaxSeverity;
        public bool IsUnderRange(int severity) => severity < MinSeverity;
    }
}
