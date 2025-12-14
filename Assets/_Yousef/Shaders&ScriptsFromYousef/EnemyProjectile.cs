using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float lifeTime = 1f;
    [SerializeField] AudioClip shotClip;

    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(DelayLifeTime(lifeTime));
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        //AudioSource.PlayClipAtPoint(shotClip, transform.position);
        AudioManager.instance.playSFX("Gun");
        DestroySelf();
    }
    void DestroySelf()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
    IEnumerator DelayLifeTime(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
