using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private Transform target;
    private float speed = 15.0f;
    private float rocketStrength = 15.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Fire(Transform newTarget)
    {
        target = newTarget;
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
            transform.Rotate(90, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(target != null && col.gameObject.CompareTag("Enemy"))
        {
            Rigidbody targetRb = col.gameObject.GetComponent<Rigidbody>();
            Vector3 away = -col.contacts[0].normal;
            targetRb.AddForce(away * rocketStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
