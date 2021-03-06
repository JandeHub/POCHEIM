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
        GameObject.FindWithTag("Player").GetComponent<HealthSystem>().MaxHealth += SetMaxHealth;
        GameObject.FindWithTag("Player").GetComponent<HealthSystem>().UpdateHealth += SetHealth;
    }

    void OnDisable()
    {
        GameObject.FindWithTag("Player").GetComponent<HealthSystem>().MaxHealth -= SetMaxHealth;
        GameObject.FindWithTag("Player").GetComponent<HealthSystem>().UpdateHealth -= SetHealth;
    }

    void SetMaxHealth(float health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;
    }
    
    void SetHealth(float health)
    {
        sliderHealth.value = health;
    }
}
