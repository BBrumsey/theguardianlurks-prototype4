using UnityEngine.InputSystem;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;

    private Vector2 moveInput;

    public float jumpForce = 5f;
    public LayerMask groundLayer;
    private bool jumpRequested;
    public DayNightCycle dayNightCycle;

    public float daySpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpRequested = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentSpeed = dayNightCycle.IsNight ? moveSpeed : daySpeed;

        rb.linearVelocity = new Vector3(
        moveInput.x * currentSpeed,
        rb.linearVelocity.y,
        moveInput.y * currentSpeed
    );

        if (jumpRequested)
        {
            bool grounded = Physics.Raycast(
                rb.position, Vector3.down, 0.6f, groundLayer
            );

            if (grounded && dayNightCycle.IsNight)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            jumpRequested = false;
        }

    }

}
