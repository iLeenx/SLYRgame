using UnityEngine;

public class DamagingEnemy : MonoBehaviour
{
    [SerializeField] int health = 20;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerShot"))
        {
            health--;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
