using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipChallengeResit_DataAccess.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public decimal? Price { get; set; }
        public int ProcedureID { get; set; }
        public int PetID { get; set; }
    }
}
