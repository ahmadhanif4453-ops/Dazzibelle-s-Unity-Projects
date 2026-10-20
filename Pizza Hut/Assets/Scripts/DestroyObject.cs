using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private float topBound = 35f;
    private float lowerBound = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            Debug.Log("You Lose! (skill issue)");
        }
    }
}
