using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest
{

    [Table("EMPLOYEES")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { set; get; }

        [Column("NAME")]
        public string Name { set; get; }

        [Column("HIREDATE")]
        public DateTime HireDate { set; get; }

        [Column("DEPARTMENTID")]
        public int? DepartmentId { set; get; }

        public virtual Department Department { set; get; }
    }
}
