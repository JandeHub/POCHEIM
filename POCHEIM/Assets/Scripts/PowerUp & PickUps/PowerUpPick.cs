using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpPick : MonoBehaviour
{

    [SerializeField]
    private GameObject pickUpParticle;

    public event Action HealthUp = delegate { };

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

        HealthUp();
        Destroy(gameObject);
        
    }

    
}
