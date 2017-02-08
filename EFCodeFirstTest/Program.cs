using System;
using System.Linq;

namespace EFCodeFirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInsert();
            TestQueryOneToMany();
            TestSQLQuery();

            TestInsertMul();
            TestQueryManyToMany();

            Console.Write("Press any key to continue... ");
            Console.ReadLine();
        }

        #region 测试插入
        public static void TestInsert()
        {
            using (var ctx = new OracleDbContext())
            {
                var emp = new Employee
                {
                    Id = 6,
                    Name = "Li",
                    HireDate = DateTime.Now

                };
                ctx.Employees.Add(emp);
                ctx.SaveChanges();

                var dept = new Department
                {
                    Id = 7,
                    Name = "LYX",
                    ManagerId = emp.Id,
                    GuidId = Guid.NewGuid(),
                    TestEnum = TestEnum.Second
                };
                ctx.Departments.Add(dept);
                ctx.SaveChanges();
            }
        }

      
        /// <summary>
        /// 测试多对多
        /// </summary>
        public static void TestInsertMul()
        {
            using (var ctx = new OracleDbContext())
            {
                var com = new Company
                {
                    Id = 4,
                    CompanyName = "Test"

                };
                ctx.Company.Add(com);
                ctx.SaveChanges();

                var per = new Person
                {
                    Id = 4,
                    Name = "LYX",
                   IsActive = true
                };
                per.Companies.Add(new PerCompany()
                {
                    CompId = com.Id,
                    PerId = per.Id,
                    Name = "Test"
                });

                ctx.Persons.Add(per);
               
                ctx.SaveChanges();
            }
        }
        #endregion

        #region 测试查询
        public static void TestQueryOneToMany()
        {
            using (var ctx = new OracleDbContext())
            {
                //var str = ctx.Departments.Where(x => x.Id == 0).Include(x => x.Manager).ToString();
                //var str1 = ctx.Departments.Where(x => x.Id == 0).ToString();

               var list  = ctx.Departments.ToList();
                var guid = Guid.Parse("299d92e6-f175-4983-b73c-1630f8b03fed");
               var list1  = ctx.Departments.Where(x => x.GuidId == guid).ToList();

            }
        }

        public static void TestQueryManyToMany()
        {
            using (var ctx = new OracleDbContext())
            {
                //var str = ctx.Departments.Where(x => x.Id == 0).Include(x => x.Manager).ToString();
                //var str1 = ctx.Departments.Where(x => x.Id == 0).ToString();

                var pers = ctx.Persons.ToList();
                var persList = ctx.Persons.Include("Companies").ToList();

            }
        }
        #endregion

        #region 测试获取自增长数据
        public static void TestIdentity()
        {

            decimal maxXh = 90000000;
            using (var entity = new OracleDbContext())
            {
                var rSeqIDQuerySQL = "select S_T_KNOWLEDGE_ARTICLES.nextval from dual";
                decimal decSeqID = entity.Database.SqlQuery<decimal>(rSeqIDQuerySQL).First();
                maxXh = decSeqID;
            }
        }
        #endregion

        #region 测试SQL查询
        public static void TestSQLQuery()
        {
            string sql = "select d.NAME DEPartmentName, e.NAME EmployeeName ,e.HIREDATE  from DEPARTMENTS d left join EMPLOYEES e on e.DEPARTMENTID = d.ID";
            using(var context = new OracleDbContext())
            {
               var dtoList = context.Database.SqlQuery<DtoTest>(sql).ToList();
            }
        }

        #endregion

        #region 存储过程
        public void TestProdure()
        {
          
            //StringBuilder sb = new StringBuilder();
            //sb.Append("WHERE c_db_status = 0 ");

            //string sql = string.Empty;
            //string sqlCount = string.Empty;

            //sql = string.Format(@"SELECT a.* FROM t_pmi_user a {0}", sb.ToString());
            //sqlCount = string.Format("SELECT count(0) FROM t_pmi_user a {0}", sb.ToString());

            ////return OracleHelper.GetSqlPageData(sql, sqlCount, "c_sort", false, para.PageSize, para.PageIndex);

            //int pi_need_rowcount = 1;
            //var p = new OracleDynamicParameters();
            //p.Add("ps_sql", sql);
            //p.Add("ps_sql_rowcount", sqlCount);
            //p.Add("ps_order_by", "c_sort");
            //p.Add("pi_order_type", 0);
            //p.Add("pi_need_rowcount", pi_need_rowcount);
            //p.Add("pi_page_size", 10);
            //p.Add("pi_page_index", 1);
            //p.Add("pi_is_sql", 0);
            //p.Add("pi_rowcount", dbType: OracleDbType.Decimal, direction: ParameterDirection.Output);
            //p.Add("cur_out1", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);


            //var result = conn.QueryMultiple("pkg_common_rs.p_paginationNew", param: p, commandType: CommandType.StoredProcedure);
            //Double countRecord = 0;
            ////这里一定要分别单独接收之后,再进行return
            //var list = result.Read<Car>().ToList();

            //var countRecord1 = p.Get<OracleDecimal, decimal>("pi_rowcount");
        }
        #endregion

        #region
   
        #endregion

    }
}
