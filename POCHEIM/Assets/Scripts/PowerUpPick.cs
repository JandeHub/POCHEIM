using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPick : MonoBehaviour
{
    [SerializeField]
    private GameObject pickUpParticle;

    public float multiplier = 1.4f;

    void OnEnable()
    {
        GetComponent<CollisionSystem>().PickUpPowerUp += pickUp;

    }

    void OnDisable()
    {
        GetComponent<CollisionSystem>().PickUpPowerUp -= pickUp;

    }

    void pickUp()
    {
        
        Instantiate(pickUpParticle, transform.position, transform.rotation);

        HealthSystem playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        
        playerStats.currentHealth *= multiplier;
        if(playerStats.currentHealth > 200)
        {
            playerStats.currentHealth = 200;
        }
        

        Destroy(gameObject);
        
    }

    
}
