using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 3.0f;
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        playerControllerScript =
        GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(startDelay);
        while (playerControllerScript.gameOver == false)
        {
            SpawnObstacle();
            float randomWaitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int randomIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randomIndex], spawnPos, obstaclePrefab[randomIndex].transform.rotation);
        }
    }
}
