using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public DamagingPlayer healthBarModifier;
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
