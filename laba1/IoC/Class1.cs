using DataAccessLayer;
using laba1;
using logic.Logic;
using laba1.BusinessLogic;
using Ninject.Modules;
using model.Entities;

namespace logic.IoC
{
    public class SimpleConfigModule : NinjectModule
    {
        private readonly string _connectionString;

        public SimpleConfigModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IRepository<Sushnost>>()
                .ToConstant(new DapperRepository<Sushnost>(_connectionString))
                .InSingletonScope();

            Bind<SushnostBusinessLogic>()
                .ToSelf()
                .InSingletonScope();

            //Bind<IRepository<Sushnost>>()
            //    .ToConstant(new EntityRepository<Sushnost>(new AppDbContext()))
            //    .InSingletonScope();

            Bind<SushnostModel>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}