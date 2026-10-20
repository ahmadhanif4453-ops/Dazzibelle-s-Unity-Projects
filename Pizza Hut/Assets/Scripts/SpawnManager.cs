using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabBinatang;
    public float posX = 20f;
    public float posZ = 20f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBinatang", startDelay, spawnInterval);
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
}
