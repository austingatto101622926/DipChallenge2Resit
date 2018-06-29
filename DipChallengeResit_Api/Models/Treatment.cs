namespace DipChallengeResit_Api.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        public int TreatmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(300)]
        public string Notes { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int ProcedureID { get; set; }

        public int PetID { get; set; }

        [JsonIgnore]
        public virtual Pet Pet { get; set; }
        
        [JsonIgnore]
        public virtual Procedure Procedure { get; set; }
    }
}
