using UnityEngine;
using UnityEngine.UI;

public class DamagingPlayer : MonoBehaviour
{
    public int health = 20;
    [SerializeField] float invincibleTimer = 3;
    [SerializeField] Image shieldIcon;
    [SerializeField] Image shieldIcon2;  // leen edited
    [SerializeField] GameObject losing;

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
            if (other.CompareTag("EnemyShot") || other.CompareTag("Obstacles"))
            {
                health--;
                if (health == 0)
                {
                    Cursor.visible = true;
                    losing.SetActive(true);
                    Time.timeScale = 0.0f;
                }
            }
        }
        if (other.CompareTag("Invincible"))
        {
            Color color = shieldIcon.color;
            color.a = 1.0f;
            shieldIcon.color = color;

            Color color2 = shieldIcon2.color;
            color2.a = 1.0f;
            shieldIcon2.color = color2;

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
            Color color = shieldIcon.color;
            color.a = 0.0f;
            shieldIcon.color = color;

            Color color2 = shieldIcon2.color;
            color2.a = 0.0f;
            shieldIcon2.color = color2;

            invincible = false;
        }
    }
}
