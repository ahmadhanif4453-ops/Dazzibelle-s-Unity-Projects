using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private float topBound = 35f;
    private float lowerBound = -10f;
    private float sideBound = 30f;
    private GameManajer gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManajer").GetComponent<GameManajer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound || transform.position.x > sideBound || transform.position.x < -sideBound)
        {
            gameManager.AddLives(-1);
            gameManager.AddMiss();
            Destroy(gameObject);
        }
       
        
    }
}
