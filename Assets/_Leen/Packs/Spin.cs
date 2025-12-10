using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 100f; // degrees per second

    void Update()
    {
        // Rotate around Y axis
        transform.Rotate( (speed * 0.5f) * Time.deltaTime, speed * Time.deltaTime, (speed * 0.5f) * Time.deltaTime);
    }
}
