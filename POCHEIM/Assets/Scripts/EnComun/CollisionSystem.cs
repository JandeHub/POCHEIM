using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{
    public event Action OnTakeCoin = delegate { };
    public event Action DamageBullet = delegate { };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnTakeCoin();

            
        }

        if(collision.gameObject.tag == "Player")
        {
            DamageBullet();
            
        }

        

        
    }

    
}


