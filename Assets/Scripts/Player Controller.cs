using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;

    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
