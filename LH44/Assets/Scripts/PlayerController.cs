using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 150f;
    private InputSystem_Actions controls;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    private float powerUpStrentgh = 15.0f;
    public GameObject powerUpIndicator;
    public PowerUpType currentPowerUp = PowerUpType.None;
    public Coroutine powerUpCountdown;
    public GameObject rocketPrefab;
    public float hangTime = 0.4f;
    public float smashSpeed = 25.0f;
    public float explosionForce = 40.0f;
    public float explosionRadius = 12.0f;
    private bool smashing = false;
    private float floorY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
    // Update is called once per frame
    private void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float forwardInput = moveInput.y;
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * playerSpeed * Time.deltaTime);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (currentPowerUp == PowerUpType.Rockets)
            {
                LaunchRockets();
            }
            else if (currentPowerUp == PowerUpType.Smash && !smashing)
            {
                smashing = true;
                StartCoroutine(SmashRoutine());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            currentPowerUp = other.GetComponent<PowerUp>().powerUpType;
            powerUpIndicator.gameObject.SetActive(true);

            if (powerUpCountdown != null)
            {
                StopCoroutine(powerUpCountdown);
            }
            powerUpCountdown = StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        currentPowerUp = PowerUpType.None;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.Pushback)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrentgh, ForceMode.Impulse);
        }
    }

    void LaunchRockets()
    {
        foreach (var enemy in FindObjectsByType<Enemy>(FindObjectsSortMode.None))
        {
            GameObject tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }

    IEnumerator SmashRoutine()
    {
        floorY = transform.position.y;

        float jumpTime = Time.time + hangTime;
        while (Time.time < jumpTime)
        {
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, smashSpeed, playerRb.linearVelocity.z);
            yield return null;
        }
        while (transform.position.y > floorY)
        {
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, -smashSpeed * 2, playerRb.linearVelocity.z);
            yield return null;
        }

        var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] != null)
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }
        }
        smashing = false;
    }
}
