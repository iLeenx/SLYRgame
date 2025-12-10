using UnityEngine;

public class PlayerFallReset : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform respawnPoint;     // Drag your spawn point here
    public float fallThresholdY = -3f; // When player falls below this Y, reset

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if player fell below threshold
        if (transform.position.y < fallThresholdY)
        {
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        // Disable CharacterController before teleporting
        controller.enabled = false;

        // Reset player position
        transform.position = respawnPoint.position;

        // Enable controller again AFTER moving
        controller.enabled = true;
    }
}
