using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    void OnEnable()
    {
        GetComponent<PowerUpPick>().HealthUp += Health;

    }

    void OnDisable()
    {
        GetComponent<PowerUpPick>().HealthUp -= Health;

    }

    void Health()
    {
        FindObjectOfType<AudioManager>().Play("HealthUp");
        HealthSystem playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();

        playerStats.currentHealth *= multiplier;
        if (playerStats.currentHealth > 100)
        {
            playerStats.currentHealth = 100;
        }
        
    }
}
