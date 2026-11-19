using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
       
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public void SetStats(float newSpeed, float newScale, Color newColor)
    {
        speed = newSpeed;
        transform.localScale = Vector3.one * newScale;
        enemyRb.mass = newScale;
        GetComponent<Renderer>().material.color = newColor;
    }
}
