using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipChallengeResit_DataAccess.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int OwnerID { get; set; }
    }
}
