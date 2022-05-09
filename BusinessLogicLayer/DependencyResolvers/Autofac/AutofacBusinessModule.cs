using Autofac;
using Autofac.Extras.DynamicProxy;
using DataAccessLayer.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using BusinessLogicLayer.Concrete.UserProcesses;
using BusinessLogicLayer.Concrete.ClientProcesses;
using BusinessLogicLayer.Concrete.CompanyProcesses;
using BusinessLogicLayer.Concrete.AuthProcesses;
using BusinessLogicLayer.Concrete.AddressProcesses;
using BusinessLogicLayer.Concrete.AuthenticateProcesses;
using BusinessLogicLayer.Concrete.LikeProcesses;
using BusinessLogicLayer.Concrete.CategoryProcesses;
using BusinessLogicLayer.Concrete.PostProcesses;
using BusinessLogicLayer.Concrete.LoginLogProcesses;
using BusinessLogicLayer.Concrete.CityProcesses;
using BusinessLogicLayer.Concrete.BasketProcesses;
using BusinessLogicLayer.Concrete.CategoryCourseProcesses;
using BusinessLogicLayer.Concrete.ClientEducationInformationProcesses;
using BusinessLogicLayer.Concrete.CommentMentorProcesses;
using BusinessLogicLayer.Concrete.CommentPostProcesses;
using BusinessLogicLayer.Concrete.FileClientProcesses;
using BusinessLogicLayer.Concrete.FileMentorProcesses;
using BusinessLogicLayer.Concrete.MentorEducationInformationProcesses;
using BusinessLogicLayer.Concrete.MentorProcesses;
using BusinessLogicLayer.Concrete.OrderProcesses;
using BusinessLogicLayer.Concrete.ParentClientProcesses;
using BusinessLogicLayer.Concrete.RoleUserProcesses;

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

            builder.RegisterType<BasketManager>().As<IBasketService>().SingleInstance();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<CategoryCourseManager>().As<ICategoryCourseService>().SingleInstance();
            builder.RegisterType<EfCategoryCourseDal>().As<ICategoryCourseDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<ClientEducationInformationManager>().As<IClientEducationInformationService>().SingleInstance();
            builder.RegisterType<EfClientEducationInformationDal>().As<IClientEducationInformationDal>().SingleInstance();

            builder.RegisterType<ClientManager>().As<IClientService>().SingleInstance();
            builder.RegisterType<EfClientDal>().As<IClientDal>().SingleInstance();

            builder.RegisterType<CommentMentorManager>().As<ICommentMentorService>().SingleInstance();
            builder.RegisterType<EfCommentMentorDal>().As<ICommentMentorDal>().SingleInstance();

            builder.RegisterType<CommentPostManager>().As<ICommentPostService>().SingleInstance();
            builder.RegisterType<EfCommentPostDal>().As<ICommentPostDal>().SingleInstance();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<CourseManager>().As<ICourseService>().SingleInstance();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>().SingleInstance();

            builder.RegisterType<DiscountManager>().As<IDiscountService>().SingleInstance();
            builder.RegisterType<EfDiscountDal>().As<IDiscountDal>().SingleInstance();

            builder.RegisterType<FileClientManager>().As<IFileClientService>().SingleInstance();
            builder.RegisterType<EfFileClientDal>().As<IFileClientDal>().SingleInstance();

            builder.RegisterType<FileMentorManager>().As<IFileMentorService>().SingleInstance();
            builder.RegisterType<EfFileMentorDal>().As<IFileMentorDal>().SingleInstance();

            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();
            builder.RegisterType<EfFileDal>().As<IFileDal>().SingleInstance();

            builder.RegisterType<LikeManager>().As<ILikeService>().SingleInstance();
            builder.RegisterType<EfLikeDal>().As<ILikeDal>().SingleInstance();

            builder.RegisterType<LoginLogManager>().As<ILoginLogService>().SingleInstance();
            builder.RegisterType<EfLoginLogDal>().As<ILoginLogDal>().SingleInstance();

            builder.RegisterType<MentorEducationInformationManager>().As<IMentorEducationInformationService>().SingleInstance();
            builder.RegisterType<EfMentorEducationInformationDal>().As<IMentorEducationInformationDal>().SingleInstance();

            builder.RegisterType<MentorManager>().As<IMentorService>().SingleInstance();
            builder.RegisterType<EfMentorDal>().As<IMentorDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<ParentClientManager>().As<IParentClientService>().SingleInstance();
            builder.RegisterType<EfParentClientDal>().As<IParentClientDal>().SingleInstance();

            builder.RegisterType<PostManager>().As<IPostService>().SingleInstance();
            builder.RegisterType<EfPostDal>().As<IPostDal>().SingleInstance();

            builder.RegisterType<RoleManager>().As<IRoleService>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();

            builder.RegisterType<RoleUserManager>().As<IRoleUserService>().SingleInstance();
            builder.RegisterType<EfRoleUserDal>().As<IRoleUserDal>().SingleInstance();

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
