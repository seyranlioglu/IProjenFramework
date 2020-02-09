using AutoMapper;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IProjenFramework.MvcWebUI.Components.Select2Component
{
    public class Select2ModelConst<T, TMapConfig> where T : class,new()
        where TMapConfig: MappingConfiguration
    {
        public static List<Select2Model> Select2ModelComponent(List<T> list)
        {
            Type type = typeof(TMapConfig);
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("CreateMap");
            
            IMapper mapper = (IMapper)method.Invoke(instance,null);
            List<Select2Model> select2 = mapper.Map<List<T>, List<Select2Model>>(list);
            return select2;
        }
    }
}