using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public DamagingEnemy healthBarModifier;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = healthBarModifier.health;
    }

    void Update()
    {
        slider.value = healthBarModifier.health;
    }
}
