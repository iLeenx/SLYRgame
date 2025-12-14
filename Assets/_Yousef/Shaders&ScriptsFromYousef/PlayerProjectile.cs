using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float lifeTime = 1f;
    [SerializeField] AudioClip projectClip;

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
        //AudioSource.PlayClipAtPoint(projectClip, transform.position);
        AudioManager.instance.playSFX("Gun");

        DestroySelf();
    }
    void DestroySelf()
    {
        CancelInvoke();
        Destroy(gameObject);
    }
}
