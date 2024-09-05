using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatsDefenceBST.BSTree;
using ThreatsDefenceBST.Models;

namespace ThreatsDefenceBST.Service
{
    internal static class ThreatUtil
    {
        public static void PrintDefenses(DefenceStrategiesBST bst, ThreatModel threat, int delay = 0)
        {
            List<string> defenses = GetDefenses(bst, threat);
            defenses.ForEach(d => { Console.WriteLine(d); Thread.Sleep(delay * 1000); });
        }

        public static List<string> GetDefenses(DefenceStrategiesBST bst, ThreatModel threat) =>
            FindDefenses(bst, threat.ComputeSeverity());

        public static List<string> FindDefenses(DefenceStrategiesBST bst, int targetValue)
        {
            List<string> defenses = new();

            DSNode? suitableNode = bst.SearchPreOrder(targetValue);

            if (suitableNode != null)
            {
                defenses.AddRange(suitableNode.Defenses);
            }
            else if (targetValue < bst.root.MinSeverity)
            {
                defenses.Add("Attack severity is below the threshold. Attack is ignored!");
            }
            else if (targetValue > bst.root.MaxSeverity)
            {
                defenses.Add("Attack severity is above the threshold. Attack is ignored!");
            }
            else
            {
                defenses.Add("No suitable defence was found. Brace for impact!");
            }
                return defenses;
        }
    }
}
