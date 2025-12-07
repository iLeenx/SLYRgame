using UnityEngine;

public class CameraMovementSpeed : MonoBehaviour
{

    public float backwardSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward) * backwardSpeed * Time.deltaTime;

    }
}
