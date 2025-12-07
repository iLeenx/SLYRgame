using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public DamagingEnemy healthCheck;

    TMP_Text healthText;
    void Start()
    {
        healthText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        healthText.text = ((int)healthCheck.health).ToString();
    }
}
