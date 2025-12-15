using UnityEngine;

public class DamagingEnemy : MonoBehaviour
{
    public int health = 20;
    [SerializeField] GameObject losing;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerShot"))
        {
            health--;
            if(health == 0)
            {
                Cursor.visible = true;
                losing.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
}
