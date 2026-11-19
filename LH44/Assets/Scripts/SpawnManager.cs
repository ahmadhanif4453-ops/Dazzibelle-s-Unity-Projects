using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerUpPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnRandomPowerup();
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        float waveSpeed = 2.0f;
        float waveScale = 1.0f;
        Color waveColor = Color.black;

        if(waveNumber % 3 == 2)
        {
            waveSpeed = 3.5f;
            waveScale = 0.7f;
            waveColor = Color.red;
        }
        else if (waveNumber % 3 == 0)
        {
            waveSpeed = 2.2f;
            waveScale = 1.6f;
            waveColor = Color.magenta;
        }

        for(int i=0; i < enemiesToSpawn; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            Enemy enemyScript = newEnemy.GetComponent<Enemy>();
            enemyScript.SetStats(waveSpeed, waveScale, waveColor);
        }
    }

    // Update is called once per frame
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0.5f, spawnPosZ);
    }

    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnRandomPowerup();
        }
    }

    void SpawnRandomPowerup()
    {
        int randomIndex = Random.Range(0, powerUpPrefab.Length);
        Instantiate(powerUpPrefab[randomIndex], GenerateSpawnPosition(), powerUpPrefab[randomIndex].transform.rotation);
    }
}
