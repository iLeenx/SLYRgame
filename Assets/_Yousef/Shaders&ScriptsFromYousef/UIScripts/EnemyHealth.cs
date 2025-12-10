using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public DamagingEnemy enemy;

    TMP_Text healthText;
    private int maxHealth;
    void Start()
    {
        healthText = GetComponent<TMP_Text>();
        maxHealth = enemy.health;
    }
    void Update()
    {
        healthText.text = $"{(int)enemy.health}/{(int)maxHealth}";
    }
}
