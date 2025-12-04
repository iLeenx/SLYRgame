using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float horizontalSpeed = 7f;
    public float backwardSpeed = 5f;

    [Header("Lane Limits")]
    public float minX = -3f;
    public float maxX = 3f;

    [Header("Floating Settings")]
    public float fixedY = 2.5f;

    [Header("Player 1 (Temporary or Real)")]
    public Transform player1;
    public float targetDistance = 10f;

    void Update()
    {
        HandleHorizontalMovement();
        MaintainDistanceFromPlayer1();
        KeepFloatingHeight();
    }

    void HandleHorizontalMovement()
    {
        float input = 0f;

        // J = move left (from player's perspective)
        if (Input.GetKey(KeyCode.J))
            input = -1f;

        // L = move right
        if (Input.GetKey(KeyCode.L))
            input = 1f;

        
        // Since Player 2 is facing Player 1, movement appears reversed.
        // This line guarantees the controls feel natural.
        input *= -1f;

        // Apply movement
        Vector3 movement = new Vector3(input * horizontalSpeed, 0, 0);
        transform.position += movement * Time.deltaTime;

        // Clamp movement within track
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    void MaintainDistanceFromPlayer1()
    {
        if (player1 == null)
        {
            transform.position += Vector3.back * backwardSpeed * Time.deltaTime;
            return;
        }

        float currentDistance = player1.position.z - transform.position.z;

        if (currentDistance < targetDistance)
        {
            transform.position += Vector3.back * backwardSpeed * Time.deltaTime;
        }
    }

    void KeepFloatingHeight()
    {
        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;
    }
}
