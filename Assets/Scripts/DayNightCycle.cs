using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleDuration = 60f;

    public bool IsNight { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationSpeed = 360f / cycleDuration;

        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        IsNight = Vector3.Dot(transform.forward, Vector3.down) <= 0f;
    }
}
