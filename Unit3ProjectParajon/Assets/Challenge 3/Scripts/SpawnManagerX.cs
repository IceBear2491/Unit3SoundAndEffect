using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float spawnDelay = 2;
    private Vector3 spawnPos = new Vector3(25, 12, 0);
    private float spawnInterval = 1.5f;
    private int randomObstacle;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObstacle()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, obstaclePrefab.Length);

        // If game is still active, spawn new object
        if (playerControllerScript.gameOver == false)
        {
            randomObstacle = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randomObstacle], spawnPos, obstaclePrefab[randomObstacle].transform.rotation);
        }

    }
}
