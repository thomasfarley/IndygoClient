using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndygoClient.Models
{
    internal class Software
    {
        public string TokenId { get; set; }
        public Token Token { get; set; }
        public string SoftwareName { private get; set; }
        public string LatestVersion { get; set; }
        public bool UseAutomaticUpdates { get; set; }
    }
}
