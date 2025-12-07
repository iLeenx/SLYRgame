using UnityEngine;

public class DamagingPlayer : MonoBehaviour
{
    public int health = 20;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyShot"))
        {
            health--;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
