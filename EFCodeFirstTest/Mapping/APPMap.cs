using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTest.Mapping
{
    public class APPMap:EntityTypeConfiguration<T_PMI_APP>
    {
        public APPMap()
        {
            Property(e => e.C_ID)
            .IsUnicode(false);
            Property(e => e.C_PARENT_ID)
            .IsUnicode(false);
            Property(e => e.C_CODE)
            .IsUnicode(false);
            Property(e => e.C_NAME)
            .IsUnicode(false);
            Property(e => e.C_DESC)
            .IsUnicode(false);
            Property(e => e.C_SORT)
            .HasPrecision(38, 0);
            Property(e => e.C_STATUS)
            .HasPrecision(38, 0);
            Property(e => e.C_DB_CREATED_ID)
            .HasPrecision(38, 0);
            Property(e => e.C_DB_UPDATED_ID)
            .HasPrecision(38, 0);
            Property(e => e.C_DB_STATUS)
            .HasPrecision(38, 0);
        }
    }
}
