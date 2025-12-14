using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] AudioClip collectClip;
    private void OnTriggerEnter(Collider other)
    {
        //AudioSource.PlayClipAtPoint(collectClip, transform.position);
        AudioManager.instance.playSFX("Gun Reload");
        Destroy(gameObject);
    }
}
