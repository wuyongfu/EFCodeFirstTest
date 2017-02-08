using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest
{
    [Table("PERCOMPANY")]
    public class PerCompany
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column("PERID" ,Order = 0)]
        public int PerId { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column("COMPID", Order = 1)]
        public int CompId { set; get; }

        [Column("NAME")]
        public string Name { set; get; }
    }
}
