using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float lifeTime = 1f;

    void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(DestroySelf), lifeTime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        DestroySelf();
    }
    void DestroySelf()
    {
        CancelInvoke();
        Destroy(gameObject);
    }
}
