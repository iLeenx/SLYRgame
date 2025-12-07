using UnityEngine;

public class Player2Thrower : MonoBehaviour
{
    // References for obstacle throwing
    [Header("Obstacle Settings")]
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Transform throwPoint;

    [Header("Throw Settings")]
    [SerializeField] public float throwSpeed = 20f;
    [SerializeField] public float cooldown = 0.5f;

    private float cooldownTimer;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        // K = throw
        if (Input.GetKeyDown(KeyCode.K) && cooldownTimer <= 0f)
        {
            ThrowObstacle();
            cooldownTimer = cooldown;
        }
    }

    void ThrowObstacle()
    {
        // Safety check for missing references
        if (obstaclePrefab == null || throwPoint == null)
        {
            Debug.LogWarning("Missing Prefab or ThrowPoint reference!");
            return;
        }

        // Create the obstacle at throw point 
        GameObject obj = Instantiate(obstaclePrefab, throwPoint.position, throwPoint.rotation);

        // Get direction from the throw point forward 
        Vector3 direction = throwPoint.forward;

        // Pass direction to the projectile 
        ObstacleProjectile projectile = obj.GetComponent<ObstacleProjectile>();
        if (projectile != null)
        {
            projectile.Init(direction, throwSpeed);
        }
    }
}
