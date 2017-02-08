using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest
{
    [Table("PERSONS")]
    public class Person
    {
        public Person()
        {
            Companies = new HashSet<PerCompany>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id
        {
            set;get;
        }

        [Column("NAME")]
        public string Name { set; get; }

        [Column("ISACTIVE")]
        public bool IsActive { set; get; } 

        [ForeignKey("PerId")]
        public virtual ICollection<PerCompany> Companies { set; get; }
    }
}
