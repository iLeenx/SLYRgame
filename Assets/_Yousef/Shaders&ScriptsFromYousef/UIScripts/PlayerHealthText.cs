using TMPro;
using UnityEngine;

public class PlayerHealthText : MonoBehaviour
{
    public DamagingPlayer player;

    TMP_Text healthText;
    private int maxHealth;
    void Start()
    {
        healthText = GetComponent<TMP_Text>();
        maxHealth = player.health;
    }
    void Update()
    {
        healthText.text = $"{(int)player.health}/{(int)maxHealth}";
    }
}
