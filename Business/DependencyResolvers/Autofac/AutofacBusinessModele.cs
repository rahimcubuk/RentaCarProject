using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract.Services;
using Business.Concrete.Managers;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.EFDals;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModele : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Car
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            #endregion

            #region Brand
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            #endregion

            #region Color
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            #endregion

            #region Customer
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            #endregion

            #region User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            #endregion

            #region Auth
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            #endregion

            #region Rental
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            #endregion

            #region CarImage
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            #endregion

            #region Payments
            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EFPaymentDal>().As<IPaymentDal>().SingleInstance();
            #endregion

            #region FakeBank
            builder.RegisterType<FakeCreditCardManager>().As<IFakeCardService>().SingleInstance();
            builder.RegisterType<EfFakeCreditCardDal>().As<IFakeCreditCardDal>().SingleInstance();
            #endregion

            #region Core.Aspect
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            #endregion
        }
    }
}
