using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float horizontalSpeed = 7f;
    public float backwardSpeed = 5f;

    [Header("Lane Limits")]
    public float minX = -3f;
    public float maxX = 3f;

    [Header("Player 1 (Temporary or Real)")]
    public Transform player1;
    public float targetDistance = 10f;

    void Update()
    {
        HandleHorizontalMovement();
        MaintainDistanceFromPlayer1();
    }

    void HandleHorizontalMovement()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(input * horizontalSpeed, 0, 0);

        transform.position += movement * Time.deltaTime;

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
}
