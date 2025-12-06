using UnityEngine;

public class ObstacleProjectile : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] public float lifeTime =7f;

    private Vector3 moveDirection;
    private float timer;

    public void Init(Vector3 direction, float projectileSpeed)
    {
        moveDirection = direction.normalized;
        speed = projectileSpeed;
    }

    void Update()
    {
        // Move forward
        transform.position += moveDirection * speed * Time.deltaTime;

        // Lifetime countdown
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
