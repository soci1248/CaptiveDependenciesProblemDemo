using Autofac;
using FluentAssertions;
using SampleDataAccess.BogusSolution1;
using SampleDataAccess.BogusSolution2;
using SampleDataAccess.ProperSolution;
using SampleDataAccess.ProperSolution2;
using SampleDataAccess.Repository;
using SampleDataAccess.WireUp;

namespace SampleDataAccessTest;

[TestClass]
public class ApplicationImageCacheMultiThreadedTest
{
    private IContainer _container = null!;

    [TestInitialize]
    public void Init()
    {
        var imageDbContext = new ImageDbContext();
        imageDbContext.Database.EnsureCreated();
        SeedData.Initialize(imageDbContext);

        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterModule<SampleDataAccessModule>();

        _container = builder.Build();
    }

    [TestMethod]
    public void ApplicationImageCacheBogus1_GetApplicationImage_WhenCalledFromManyThread_ShouldNotThrow()
    {
        //Arrange
        Action a = () => Parallel.For(0, 100, i =>
        {
            using var scope = _container.BeginLifetimeScope();

            //Act
            scope.Resolve<IApplicationImageCacheBogus1>().GetApplicationImage((ImageType)(i % 3));
        });

        //Assert
        a.Should().NotThrow();
    }

    [TestMethod]
    public async Task ApplicationImageCacheBogus1_GetApplicationImage_WhenCalledFromManyThreadMoreAggressively_ShouldNotThrow()
    {
        //Arrange
        List<Task> tasks = Enumerable.Range(0, 100).Select(i => new Task(() =>
        {
            using var scope = _container.BeginLifetimeScope();
            scope.Resolve<IApplicationImageCacheBogus1>().GetApplicationImage((ImageType)(i % 3));
        })).ToList();

        //Act
        foreach (var task in tasks)
        {
            task.Start();
        }

        Func<Task> action = async () => await Task.WhenAll(tasks);

        //Assert
        await action.Should().NotThrowAsync();
    }

    [TestMethod]
    public async Task ApplicationImageCacheBogus2_GetApplicationImage_WhenCalledFromManyThread_ShouldNotThrow()
    {
        //Arrange
        List<Task> tasks = Enumerable.Range(0, 100).Select(i => new Task(() =>
        {
            using var scope = _container.BeginLifetimeScope();
            scope.Resolve<IApplicationImageCacheBogus2>().GetApplicationImage((ImageType)(i % 3));
        })).ToList();

        //Act
        foreach (var task in tasks)
        {
            task.Start();
        }

        Func<Task> action = async () => await Task.WhenAll(tasks);

        //Assert
        await action.Should().NotThrowAsync();
    }

    [TestMethod]
    public async Task ApplicationImageCache_GetApplicationImage_WhenCalledFromManyThread_ShouldNotThrow()
    {
        //Arrange
        List<Task> tasks = Enumerable.Range(0, 100).Select(i => new Task(() =>
        {
            using var scope = _container.BeginLifetimeScope();
            scope.Resolve<IApplicationImageCache>().GetApplicationImage((ImageType)(i % 3));
        })).ToList();

        //Act
        foreach (var task in tasks)
        {
            task.Start();
        }

        Func<Task> action = async () => await Task.WhenAll(tasks);

        //Assert
        await action.Should().NotThrowAsync();
    }

    [TestMethod]
    public async Task ApplicationImageCache2_GetApplicationImage_WhenCalledFromManyThread_ShouldNotThrow()
    {
        //Arrange
        List<Task> tasks = Enumerable.Range(0, 100).Select(i => new Task(() =>
        {
            using var scope = _container.BeginLifetimeScope();
            scope.Resolve<IApplicationImageCache2>().GetApplicationImage((ImageType)(i % 3));
        })).ToList();

        //Act
        foreach (var task in tasks)
        {
            task.Start();
        }

        Func<Task> action = async () => await Task.WhenAll(tasks);

        //Assert
        await action.Should().NotThrowAsync();
    }
}