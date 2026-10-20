using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed;

    public InputAction MoveAction;
    public Vector2 moveInput;
    public string inputID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame

    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();

        float horizontalInput = Input.GetAxis("Horizontal" + inputID);
        float verticalInput = Input.GetAxis("Vertical" + inputID);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
