using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabBinatang;
    public float posX = 20f;
    public float posZ = 20f;
    public float sideSpawnMinZ = 0f;
    public float sideSpawnMaxZ = 15f;
    private float startDelay = 2f;
    public float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBinatang", startDelay, spawnInterval);
        InvokeRepeating("SpawnKiri", startDelay + 0.5f, spawnInterval);
        InvokeRepeating("SpawnKanan", startDelay + 1.0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBinatang()
    {
        int animalIndex = Random.Range(0, prefabBinatang.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-posX, posX), 0, posZ);
            Instantiate(prefabBinatang[animalIndex], spawnPos, prefabBinatang[animalIndex].transform.rotation);
    }

    void SpawnKiri()
    {
        int animalIndex = Random.Range(0, prefabBinatang.Length);
            Vector3 spawnPos = new Vector3(-posX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
            Vector3 rotation = new Vector3(0, 90, 0);
            Instantiate(prefabBinatang[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    void SpawnKanan()
    {
        int animalIndex = Random.Range(0, prefabBinatang.Length);
            Vector3 spawnPos = new Vector3(posX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
            Vector3 rotation = new Vector3(0, -90, 0);
            Instantiate(prefabBinatang[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }
}
