using IProjenFramework.MvcWebUI.SearchableModels;
using IProjenFramework.MvcWebUI.SearchableModels.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.DependencyResolvers
{
    public class DependencyResolverMvc : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDataTableSearch<>)).To(typeof(DataTableSearch<>)).InSingletonScope();
            Bind(typeof(IDataTableOrder<>)).To(typeof(DataTableOrder<>)).InSingletonScope();
        }
    }
}