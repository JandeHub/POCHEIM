using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{
    public event Action PickUpPowerUp = delegate { };
    public event Action DamageBullet = delegate { };


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           PickUpPowerUp();

            
        }

        if(other.gameObject.tag == "Player")
        {
            DamageBullet();
            
        }

        

        
    }

    
}


