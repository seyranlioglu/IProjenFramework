using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using IProjenFramework.Log4Net.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Log4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentManager manager = new DepartmentManager();
            manager.GetDepartments(875331);
            Console.ReadLine();
        }
    }

    public class DepartmentManager
    {
        [LogAspect(typeof(DatabaseLogger))]
        public List<Departments> GetDepartments(int Id)
        {
            using(var db = new IProjenFrameworkDBEntities())
            {
                return db.Departments.Where(k => k.Id == Id).ToList();
            }
        }
    }
}
