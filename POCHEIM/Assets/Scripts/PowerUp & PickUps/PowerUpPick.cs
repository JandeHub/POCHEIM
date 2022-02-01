using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPick : MonoBehaviour
{
    [SerializeField]
    private GameObject pickUpParticle;

    public float amount;
    public float duration;

    public float multiplier = 1.4f;

    void OnEnable()
    {
        GetComponent<CollisionSystem>().PickUpPowerUp += pickUp;

    }

    void OnDisable()
    {
        GetComponent<CollisionSystem>().PickUpPowerUp -= pickUp;

    }
    private void Start()
    {

        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.deltaTime * .02f;

    }
    void pickUp()
    {
        
        Instantiate(pickUpParticle, transform.position, transform.rotation);
        /*
        HealthSystem playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        
        playerStats.currentHealth *= multiplier;
        if(playerStats.currentHealth > 200)
        {
            playerStats.currentHealth = 200;
        }*/
        SlowMo.Activate(amount, duration);


        Destroy(gameObject);
        
    }

    
}
