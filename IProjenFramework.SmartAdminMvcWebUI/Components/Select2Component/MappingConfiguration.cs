using AutoMapper;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Components.Select2Component
{
    public interface MappingConfiguration
    {
        IMapper CreateMap();
    }

    public class DepartmentMap : MappingConfiguration
    {
        public IMapper CreateMap()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, Select2Model>().ForMember(dest => dest.Name, from => from.MapFrom(s => s.Name));
            });
            return config.CreateMapper();
        }
    }

    public class FormMap : MappingConfiguration
    {
        public IMapper CreateMap()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Form, Select2Model>().ForMember(dest => dest.Name, from => from.MapFrom(s => s.Name));
            });
            return config.CreateMapper();
        }
    }

    public class UserMap : MappingConfiguration
    {
        public IMapper CreateMap()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, Select2Model>().ForMember(dest => dest.Name, from => from.MapFrom(s => s.Name + " " + s.Surname));
            });
            return config.CreateMapper();
        }
    }
}