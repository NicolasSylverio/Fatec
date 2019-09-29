using AutoMapper;
using Fatec.Application.AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.Services;
using Fatec.CrossCutting.Interfaces;
using Fatec.DataBase.Repository;
using Fatec.Identity.Context;
using Fatec.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using Fatec.DataBase.Context;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Fatec.DataBase.Interfaces;

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
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<IUserStore<IdentityUser>, UserStore<IdentityUser>>();

            container.RegisterType<IVagaEstagioRepository, VagaEstagioRepository>();
            container.RegisterType<IVagaEstagioAppService, VagaEstagioAppService>();

            container.RegisterType<IVagaEmpregoRepository, VagaEmpregoRepository>();
            container.RegisterType<IVagaEmpregoAppService, VagaEmpregoAppService>();

            container.RegisterType<IEmpresaRepository, EmpresaRepository>();
            container.RegisterType<IEmpresaAppService, EmpresaAppService>();

            container.RegisterType<ITagsAppService, TagsAppService>();
            container.RegisterType<ITagsRepository, TagsRepository>();

            var mapperConfig = AutoMapperConfig.RegisterMappings();
            _ = mapperConfig.CreateMapper();
            container.RegisterType<IMapper, Mapper>(new InjectionConstructor(mapperConfig));

            container.RegisterInstance<IDbContext>(new IntranetFatecContext("server = aws - mysql.marcelomb.com; port = 3306; database = Fatec; uid = fatec; password =}Xy#6[k@,=Yte.Y("));
            container.RegisterType<IDbContext, ApplicationDbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}