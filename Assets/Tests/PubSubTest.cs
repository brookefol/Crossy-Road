//Afua Anyadike
using NUnit.Framework;
using UnityEngine;
using System;

public class PubSubTest
{
    // Dummy spawner for testing
    class DummyCarSpawner : ICarSpawner
    {
        public int spawnCount = 0;
        public void SpawnCar()
        {
            spawnCount++;
        }
    }

    private bool gameOverTriggered;
    private bool gameResetTriggered;
    private DummyCarSpawner carSpawner;  
    private SpawnProxy spawnProxy;       

    // ---------------------
    // Setup / TearDown
    // ---------------------
    [SetUp]
    public void Setup()
    {

        gameOverTriggered = false;
        gameResetTriggered = false;

        GameEvents.OnGameOver += OnGameOver;
        GameEvents.OnGameReset += OnGameReset;
    }

    [TearDown]
    public void TearDown()
    {
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.OnGameReset -= OnGameReset;
    }

    private void OnGameOver()
    {
        gameOverTriggered = true;
    }

    private void OnGameReset()
    {
        gameResetTriggered = true;
    }

    [Test]
    public void GameOverEvent_TriggersSubscribers()
    {
        GameEvents.TriggerGameOver();
        Assert.IsTrue(gameOverTriggered, "OnGameOver subscribers did not trigger.");
    }

    [Test]
    public void GameResetEvent_TriggersSubscribers()
    {
        GameEvents.TriggerGameReset();
        Assert.IsTrue(gameResetTriggered, "OnGameReset subscribers did not trigger.");
    }

    [Test]
    public void UnsubscribedSubscriber_DoesNotReceiveEvent()
    {
        bool tempTriggered = false;
        Action tempSubscriber = () => tempTriggered = true;

        GameEvents.OnGameOver += tempSubscriber;
        GameEvents.OnGameOver -= tempSubscriber;

        GameEvents.TriggerGameOver();

        Assert.IsFalse(tempTriggered, "Unsubscribed subscriber was incorrectly called.");
    }

    [Test]
    public void SpawnProxy_StopsSpawning_OnGameOver()

    {
         // Initialize dummy spawner and proxy
        carSpawner = new DummyCarSpawner();
        spawnProxy = new SpawnProxy(carSpawner);

        GameEvents.TriggerGameOver(); 
        spawnProxy.TrySpawn(Time.time);
        Assert.AreEqual(0, carSpawner.spawnCount, "SpawnProxy should not spawn after GameOver");
    }

}