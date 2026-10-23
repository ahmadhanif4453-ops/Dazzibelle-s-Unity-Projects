using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;
    public float sprint = 20.0f;
    public float xRange = 10f;
    public float zMin = -5f;
    public float zMax = 15f;
    public GameObject projectilePrefab;
    public InputAction fireAction;
    public InputAction sprintAction;
    public AudioClip shootSound;
    private AudioSource playerAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
        sprintAction.Enable();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        float currentSpeed = speed; 
        if(sprintAction.IsInProgress())
        {
            currentSpeed = sprint;
        }

        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * Time.deltaTime * currentSpeed);

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }
        if(transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }
        if(fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(shootSound, 1.0f);
        }
    }   
}
