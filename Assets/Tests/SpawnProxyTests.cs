// Angie Siagailo

using NUnit.Framework;
using NSubstitute;

public class SpawnProxyTests
{
    private SpawnProxy proxy;
    private ICarSpawner mockSpawner;

    [SetUp]
    public void Setup()
    {
        mockSpawner = Substitute.For<ICarSpawner>();
        proxy = new SpawnProxy(mockSpawner);
    }

    [Test]
    public void TrySpawn_FirstCall_SpawnsCar()
    {
        proxy.TrySpawn(10f);

        mockSpawner.Received(1).SpawnCar();
    }

    [Test]
    public void TrySpawn_TooSoon_DoesNotSpawnAgain()
    {
        proxy.TrySpawn(10f);
        proxy.TrySpawn(10.2f);

        mockSpawner.Received(1).SpawnCar();
    }

    [Test]
    public void TrySpawn_AfterEnoughTime_SpawnsAgain()
    {
        proxy.TrySpawn(10f);
        proxy.TrySpawn(11f);

        mockSpawner.Received(2).SpawnCar();
    }
}
