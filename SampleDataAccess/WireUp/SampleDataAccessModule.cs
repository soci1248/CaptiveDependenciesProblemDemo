using Autofac;
using SampleDataAccess.BogusSolution1;
using SampleDataAccess.BogusSolution2;
using SampleDataAccess.ProperSolution;
using SampleDataAccess.ProperSolution2;
using SampleDataAccess.Repository;

namespace SampleDataAccess.WireUp;

public class SampleDataAccessModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApplicationImageCacheBogus1>().As<IApplicationImageCacheBogus1>().SingleInstance();
        builder.RegisterType<ApplicationImageCacheBogus2>().As<IApplicationImageCacheBogus2>().SingleInstance();

        builder.RegisterType<ImageDbContext>().As<IImageDbContext>().InstancePerLifetimeScope();
        builder.RegisterType<ApplicationImageRepository>().As<IApplicationImageRepository>().InstancePerLifetimeScope();

        builder.RegisterType<ApplicationImageCache>().As<IApplicationImageCache>().InstancePerLifetimeScope();
        builder.RegisterType<ApplicationImageCacheStorage>().As<IApplicationImageCacheStorage>().SingleInstance();

        builder.RegisterType<ApplicationImageCache2>().As<IApplicationImageCache2>().InstancePerLifetimeScope();
        builder.RegisterType<ApplicationImageCacheStorage2>().As<IApplicationImageCacheStorage2>().SingleInstance();
    }
}