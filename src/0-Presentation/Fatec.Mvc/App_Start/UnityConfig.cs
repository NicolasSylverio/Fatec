using AutoMapper;
using Fatec.Application.AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.Services;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Infra.Data.Repositories;
using Fatec.Infra.DataBase.Context;
using Fatec.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace Fatec.Mvc
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // Identity
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IUserStore<IdentityUser>, UserStore<IdentityUser>>();

            // container.RegisterType<DbContext, IntranetFatecContext>(new HierarchicalLifetimeManager(), new InjectionConstructor("server=xxx.com;port=3306;database=intranet;uid=xxxx;password=xxxxx"));

            container.RegisterType<IVagaEstagioRepository, VagaEstagioRepository>();
            container.RegisterType<IVagaEstagioAppService, VagaEstagioAppService>();
            container.RegisterType<IEmpresaRepository, EmpresaRepository>();
            container.RegisterType<IEmpresaAppService, EmpresaAppService>();

            container.RegisterType<IVagaEmpregoAppService, VagaEmpregoAppService>();

            var mapperConfig = AutoMapperConfig.RegisterMappings();
            var mapper = mapperConfig.CreateMapper();
            container.RegisterType<IMapper, Mapper>(new InjectionConstructor(mapperConfig));
            //container.RegisterInstance(mapper, Activator.CreateInstance<T>());

            container.RegisterType<IDbContext, IntranetFatecContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}