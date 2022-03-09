using Autofac;
using Autofac.Extras.DynamicProxy;
using DataAccessLayer.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();

            builder.RegisterType<AuthenticateManager>().As<IAuthenticateService>().SingleInstance();
            builder.RegisterType<EfAuthenticateDal>().As<IAuthenticateDal>().SingleInstance();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<CourseManager>().As<ICourseService>().SingleInstance();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ClientManager>().As<IClientService>().SingleInstance();
            builder.RegisterType<EfClientDal>().As<IClientDal>().SingleInstance();

            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
