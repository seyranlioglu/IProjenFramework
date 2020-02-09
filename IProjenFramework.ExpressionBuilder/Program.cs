using IProjenFramework.Business.Concrete;
using IProjenFramework.Business.DependencyResolvers.Ninject;
using IProjenFramework.Core.ExpressionBuilder.Common;
using IProjenFramework.Core.ExpressionBuilder.Exceptions;
using IProjenFramework.Core.ExpressionBuilder.Generics;
using IProjenFramework.Core.ExpressionBuilder.Operations;
using IProjenFramework.Core.ExpressionBuilder.Orders;
using IProjenFramework.DataAccess.Concrete;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.ExpressionBuilder.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.ExpressionBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<DepartmentDal>();
            DepartmentManager manager = new DepartmentManager(memberService);

            var filter = new Filter<Department>();
            filter.By("Name", Operation.Contains, "1904", Connector.Or)
                .Or.By("Name", Operation.Contains, "2016", Connector.Or)
                .And.Group.By("Description", Operation.Contains, "SERV", Connector.And);

            var order = new OrderHelper<Department>();

            var model = manager.GetAllDepartments(filter, orderby: order.OrderByFunc("Id", true), skip: 0, take: 10);
        }

        public void Method1()
        {
            try
            {
                var memberService = InstanceFactory.GetInstance<DepartmentDal>();
                DepartmentManager manager = new DepartmentManager(memberService);

                Search Allsearch = new Search
                {
                    value = "ENERJİ"
                };
                Search nameSearch = new Search
                {
                    value = "1904"
                };
                Search descSearch = new Search
                {
                    value = "orge"
                };
                List<Column> columns = new List<Column>
            {
                new Column { name="Name",searchable=true,orderable=true,search = nameSearch },
                new Column { name="Description",searchable=true,orderable=true,search = descSearch }
            };

                DataTableAjaxPostModel dataTable = new DataTableAjaxPostModel()
                {
                    columns = columns,
                    search = Allsearch,
                };

                var filter = new Filter<Department>();
                if (dataTable.search != null)
                {
                    foreach (var item in dataTable.columns)
                    {
                        filter.By(item.name, Operation.Contains, dataTable.search.value, Connector.
                            And);
                    }
                }
                //filter.Group.By("Description", Operation.Contains, "orge", Connector.And);
                List<OrderInfo> orderInfos = new List<OrderInfo>
                {
                    new OrderInfo{ OrderType = OrderType.ASC, Property = "Name" }
                };

                var order = new OrderHelper<Department>();


                var model = manager.GetAllDepartments(filter, orderby: order.OrderByFunc("Name", false), skip: 0, take: 10);
            }
            catch (UnsupportedOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
