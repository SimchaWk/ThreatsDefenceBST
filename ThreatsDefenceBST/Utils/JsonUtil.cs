// Ignore Spelling: Defence json

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatsDefenceBST.BSTree;
using ThreatsDefenceBST.Models;

namespace ThreatsDefenceBST.Service
{
    internal static class JsonUtil
    {
        public static List<DSNode> LoadDefensesFromJson(string jsonFilePath)
        {
            string jsonData = File.ReadAllText(jsonFilePath);

            List<DSNode> defenseNodes = JsonConvert.DeserializeObject<List<DSNode>>(jsonData);

            return defenseNodes;
        }

        public static void SaveDefensesToJson(List<DSNode> nodes, string jsonFilePath)
        {
            string jsonData = JsonConvert.SerializeObject(nodes, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonData);
        }

        public static void ExportTreeToJson(DefenceStrategiesBST dst, string jsonFilePath)
        {
            List<DSNode> nodes = dst.InOrder();
            SaveDefensesToJson(nodes, jsonFilePath);
        }


        public static List<ThreatModel> LoadThreatssFromJson(string jsonFilePath)
        {
            string jsonData = File.ReadAllText(jsonFilePath);

            List<ThreatModel> threats = JsonConvert.DeserializeObject<List<ThreatModel>>(jsonData);

            return threats;
        }
    }
}
