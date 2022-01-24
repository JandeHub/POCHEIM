using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemUI : MonoBehaviour
{
    [SerializeField]
    private Slider sliderHealth;

    void OnEnable()
    {
        GameObject.Find("Player").GetComponent<HealthSystem>().MaxHealth += SetMaxHealth;
        GameObject.Find("Player").GetComponent<HealthSystem>().UpdateHealth += SetHealth;
    }

    void OnDisable()
    {
        GameObject.Find("Player").GetComponent<HealthSystem>().MaxHealth -= SetMaxHealth;
        GameObject.Find("Player").GetComponent<HealthSystem>().UpdateHealth -= SetHealth;
    }

    void SetMaxHealth(int health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;
    }
    
    void SetHealth(int health)
    {
        sliderHealth.value = health;
    }
}
