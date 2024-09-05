// Ignore Spelling: Defence Tomer

using ThreatsDefenceBST.BSTree;
using ThreatsDefenceBST.Models;
using static ThreatsDefenceBST.Service.JsonUtil;
using static ThreatsDefenceBST.Service.ThreatUtil;

namespace ThreatsDefenceBST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TomerProgram();
        }

        public static void TomerProgram()
        {
            Console.WriteLine("Generate A DefenceStrategiesBST from a JSON file\n");
            DefenceStrategiesBST defencesTree = new();

            string defenseJsonPath = "../../../JsonFiles/defenceStrategiesBalanced.json";
            string threatJsonPath = "../../../JsonFiles/threats.json";

            List<DSNode> nodes = LoadDefensesFromJson(defenseJsonPath);

            defencesTree.AddRange(nodes);

            Thread.Sleep(4000);
            Console.WriteLine("Visual print of the tree in PreIrder method:");
            Thread.Sleep(1000);
            defencesTree.PrintTreePreOrderVisual(1);

            Thread.Sleep(4000);
            Console.WriteLine("\nLoading attacks from a Json file into a local variable\n");
            List<ThreatModel> threats = LoadThreatssFromJson(threatJsonPath);

            Thread.Sleep(4000);
            Console.WriteLine($"Print the loaded attacks:");
            Thread.Sleep(1000);
            Console.WriteLine(string.Join("\n\n", threats));

            Thread.Sleep(4000);
            Console.WriteLine("\nRunning each attack, looking for suitable protection in the tree,\r\nPrinting the attack details & defense found for it or known to be suitable");
            threats.ForEach(threat =>
                {
                    Console.WriteLine($"\n\n{threat.ToString()}\nresult:");
                    PrintDefenses(defencesTree, threat, 1);
                });

            Console.WriteLine("Ended successfully!\n");
        }
    }
}
