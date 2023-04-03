using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Nagarro.VendingMachine.Authentication;
using Nagarro.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.Payment;
using System.Configuration;
using Autofac;
using System.Reflection;

namespace RemoteLearning.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            IContainer container = Container();
            container.Resolve<IVendingMachineApplication>().Run();
        }

        private static IContainer Container()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<Shelfview>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

            builder.RegisterType<CardPaymentTerminal>().As<ICardPaymentTerminal>();
            builder.RegisterType<CashPaymentTerminal>().As<ICashPaymentTerminal>();
            Assembly paymentAlgorithms = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(paymentAlgorithms).As<IPaymentAlgorithm>();
            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();

            string connectionString = ConfigurationManager.ConnectionStrings["Products"].ConnectionString;
            builder.Register(x => new SQLiteProductRepository(connectionString)).As<IProductRepository>();

            Assembly useCases = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(useCases).As<IUseCase>();

            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
            
            return builder.Build();
        }

        
    }
}