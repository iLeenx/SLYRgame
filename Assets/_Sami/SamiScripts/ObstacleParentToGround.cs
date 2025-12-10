using UnityEngine;

public class ObstacleParentToGround : MonoBehaviour
{
    private bool hasParented = false;
    private Collider obstacleCollider;

    void Start()
    {
        obstacleCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if we've already parented to avoid re-parenting
        if (hasParented)
            return;

        // Check if the collision is with a ground object
        // You can use tags, layers, or specific object names
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Parent this obstacle to the ground
            transform.SetParent(collision.transform);
            hasParented = true;
        }
    }
}
