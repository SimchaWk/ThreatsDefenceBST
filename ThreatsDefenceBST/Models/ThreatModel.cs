using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatsDefenceBST.Models
{
    internal class ThreatModel
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public ThreatModel(string threatType, int volume, int sophistication, string target)
        {
            ThreatType = threatType;
            Volume = volume;
            Sophistication = sophistication;
            Target = target;
        }

        public int ComputeSeverity()
        {
            int targetValue = Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };
            return (Volume * Sophistication) + targetValue;
        }

        public override string ToString() => 
            $"ThreatType: {ThreatType}, \n" +
            $"Volume: {Volume}, \n" +
            $"Sophistication: {Sophistication}, \n" +
            $"Target: {Target}, \n" +
            $"Severity: {ComputeSeverity()}";
    }
}
