using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipChallengeResit_DataAccess.Models
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
