using System.Data.SqlClient;
using DotNet.Standard.NParsing.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNet.Standard.NParsing.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*var dal = ObHelper.Create<EmployeInfo, Employe>("database=NSmart.Demo01;server=.;uid=sa;pwd=1;Pooling=true;Connection Timeout=300;", "DotNet.Standard.NParsing.SQLServer");
            var list = dal.SqlText("SELECT * FROM Employes WHERE ID=@ID", new SqlParameter("@ID", 1)).ToList();*/
            var dal = ObHelper.Create<EmployeInfo, Employe>("database=NSmart.Demo01;server=.;uid=sa;pwd=1;Pooling=true;Connection Timeout=300;", "DotNet.Standard.NParsing.SQLServer");
            var query = dal
                .Where(o => o.DepartmentId.In(1, 2, 3))
                .GroupBy(o => new
                {
                    o.Gender,
                    o.Department.Id,
                    o.Department.Name,
                })
                .Select(o => new
                {
                    Age = o.Avg(k => k.Age),
                    Name = o.Min(k => k.Id)
                })
                .Where(o => o.Age > 20)
                .OrderByDescending(o => new
                {
                    o.Name,
                    o.Department.Id
                })
                .OrderBy(o => o.Department.Name)
                .Join(o => new
                {
                    o.Department,
                    o.Department.Director
                });
            var list = query.ToList();
            
            var a = list;

        }
    }
}