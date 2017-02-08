using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest
{
    [Table("COMPANY")]
    public class Company
    {
        public Company()
        {
            Persons = new HashSet<PerCompany>();
        }
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }

        [Column("COMPANYNAME")]
        public string CompanyName { set; get; }

        [ForeignKey("CompId")]
        public virtual ICollection<PerCompany> Persons { set; get; }

    }
}
