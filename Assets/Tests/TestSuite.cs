using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class TestSuite
{
    private GameObject game;
    private GameManager gameManager;
    private Player player;

    [SetUp]
    public void Setup()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Game");
        game = Object.Instantiate(prefab);

        gameManager = GameManager.Instance;
        //player = Object.FindObjectOfType<Player>();
        player = game.GetComponentInChildren<Player>();
    }

    [UnityTest]
    public IEnumerator GamePrefabLoaded()
    {
        yield return new WaitForEndOfFrame();
        Assert.NotNull(game, "Oi cunt, the game prefab's gone walkabout! Strewth, mate!");
    }

    public IEnumerator PlayerExists()
    {
        yield return new WaitForEndOfFrame();
        Assert.NotNull(player, "The player doesn't exist! Fix this, maggot!");
    }

    /*
    [UnityTest]
    IEnumerator ItemCollidesWithPlayer()
    {
        yield return new WaitForEndOfFrame();
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Entities/Item");
    }
    */

    [UnityTest]
    public IEnumerator ItemCollidesWithPlayer()
    {
        //Item item = gameManager.itemManager.GetItem(0);
        //item.transform.position = player.transform.position;

        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Entities/Item");

        Vector3 playerPosition = player.transform.position;
        GameObject item = Object.Instantiate(itemPrefab, playerPosition, Quaternion.identity);



        yield return new WaitForFixedUpdate();
        yield return new WaitForEndOfFrame();



        Assert.IsTrue(item == null);
    }

    [UnityTest]
    public IEnumerator ItemCollectedAndScoreAdded()
    {
        // Spawn an item (same as above)
        // Record old score in an int

        // WaitForFixedUpdate
        // WaitForEndOfFrame

        // Assert IsTrue old score != new score


        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Entities/Item");

        Vector3 playerPosition = player.transform.position;
        GameObject item = Object.Instantiate(itemPrefab, playerPosition, Quaternion.identity);

        int oldScore = gameManager.score;

        yield return new WaitForFixedUpdate();
        yield return new WaitForEndOfFrame();

        int newScore = gameManager.score;

        Assert.IsTrue(newScore > oldScore);
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(gameManager);
    }
}
