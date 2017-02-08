using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest
{
    [Table("DEPARTMENTS")]
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { set; get; }

        [Column("NAME")]
        public string Name { set; get; }

        [Column("GUIDID")]
        public Guid? GuidId { set; get; }

        [Column("TESTENUM")]
        public TestEnum? TestEnum
        {
            set;get;
        }

        [Column("MANAGERID")]
        /// <summary>
        /// 部门主管
        /// </summary>
        public int? ManagerId { set; get; }

        /// <summary>
        /// 部门主管
        /// </summary>
        public virtual Employee Manager { set; get; }

        public virtual ICollection<Employee> Employees { set; get; }
    }

    public enum TestEnum
    {
        First,
        Second,
        Third
    }
}
