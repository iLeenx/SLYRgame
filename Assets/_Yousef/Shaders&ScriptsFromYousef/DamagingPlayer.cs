using UnityEngine;

public class DamagingPlayer : MonoBehaviour
{
    public int health = 20;
    [SerializeField] float invincibleTimer = 3;


    private bool invincible = false;
    private float timer = 0;

    private int maxHealth;
    void Start()
    {
        maxHealth = health;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!invincible)
        {
            if (other.CompareTag("EnemyShot"))
            {
                health--;
                if (health == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        if (other.CompareTag("Invincible"))
        {
            invincible = true;
            timer = invincibleTimer;
        }
        if (other.CompareTag("Health"))
        {
            health = Mathf.Min(health + 1, maxHealth);
        }
    }
    void Update()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            invincible = false;
        }
    }
}
