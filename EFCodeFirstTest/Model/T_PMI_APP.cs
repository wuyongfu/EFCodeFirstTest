namespace EFCodeFirstTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("T_PMI_APP")]
    public partial class T_PMI_APP
    {
        [Key]
        [StringLength(36)]
        public string C_ID { get; set; }

        [Required]
        [StringLength(36)]
        public string C_PARENT_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string C_CODE { get; set; }

        [Required]
        [StringLength(256)]
        public string C_NAME { get; set; }

        [StringLength(512)]
        public string C_DESC { get; set; }

        public decimal C_SORT { get; set; }

        public decimal? C_STATUS { get; set; }

        public DateTime C_DB_CREATED_DATE { get; set; }

        public decimal C_DB_CREATED_ID { get; set; }

        public DateTime C_DB_UPDATED_DATE { get; set; }

        public decimal C_DB_UPDATED_ID { get; set; }

        public decimal C_DB_STATUS { get; set; }
    }
}
