using UnityEngine;

public class HealingPlayer : MonoBehaviour
{
    [SerializeField] AudioClip HealthCollectingSound;
    [SerializeField] DamagingPlayer playerHealth;
    int healthState;

    void Start()
    {
        healthState = playerHealth.health;
    }
    void OnTriggerEnter(Collider other)
    {
        if(playerHealth.health < healthState)
        {
            if(other.CompareTag("Player"))
            {
                AudioSource.PlayClipAtPoint(HealthCollectingSound, transform.position);
                playerHealth.health += 1;
            }
        }
    }
}
