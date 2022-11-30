using WebPlanner.DAL.Interfaces;
using WebPlanner.DAL.Repositories;

namespace WebPlanner
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IDigitalTVreceiverRepository,DigitalTVreceiverRepository>();
            services.AddScoped<IElectronicBookRepository, ElectronicBookRepository>();
            services.AddScoped<IFitnessBraceletRepository, FitnessBraceletRepository>();
            services.AddScoped<IHeadphonesConstructionRepository, HeadphonesConstructionRepository>();
            services.AddScoped<IHeadphonesRepository, HeadphonesRepository>();
            services.AddScoped<IItemGroupRepository, ItemGroupRepository> ();
            services.AddScoped<ILightProjectorSourceRepository, LightProjectorSourceRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository> ();
            services.AddScoped<IMaterialsRepository, MaterialsRepository> ();
            services.AddScoped<IMayDayRepository, MayDayRepository> ();
            services.AddScoped<IOperatingSystemRepository, OperatingSystemRepository> ();
            services.AddScoped<IProjectorMatrixTypeRepository, ProjectorMatrixTypeRepository> ();
            services.AddScoped<IProjectorPurposeRepository, ProjectorPurposeRepository> ();
            services.AddScoped<IProjectorRepository, ProjectorRepository> ();
            services.AddScoped<IScreenTypeRepository, ScreenTypeRepository> ();
            services.AddScoped<ISmartPhoneRepository, SmartPhoneRepository> ();
            services.AddScoped<IStandartsWithTVresiversRepository, StandartsWithTVresiversRepository> ();
            services.AddScoped<ITabletRepository, TabletRepository> ();
            services.AddScoped<ITelevisionRepository, TelevisionRepository> ();
            services.AddScoped<ITV_TypeRepository, TV_TypeRepository> ();
            services.AddScoped <ITVresiversStandartRepository, TVresiversStandartRepository> ();
        }
        public static void AddServices(this IServiceCollection services)
        {
            
        }


    }
}
