using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Ninject.Modules;

namespace WebApiUI
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("DefaultConnection");
            Bind<ISkillService>().To<SkillService>();
            Bind<IProgrammerService>().To<ProgrammerService>();
            Bind<IReportService>().To<ReportService>();
        }
    }
}