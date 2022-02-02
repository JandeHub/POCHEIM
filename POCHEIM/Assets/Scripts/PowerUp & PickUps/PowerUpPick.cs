using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPick : MonoBehaviour
{

    [SerializeField]
    private GameObject pickUpParticle;

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
       
    }
    void pickUp()
    {
        
        Instantiate(pickUpParticle, transform.position, transform.rotation);

        Destroy(gameObject);
        
    }

    
}
