using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthSystem playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();

        playerStats.currentHealth *= multiplier;
        if (playerStats.currentHealth > 100)
        {
            playerStats.currentHealth = 100;
        }
        
    }
}
