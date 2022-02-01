using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{

    private SpriteRenderer _sp;

    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _sp.enabled = false;

            CoinAmount._instance.Money(1f);
            FindObjectOfType<AudioManager>().Play("TakeCoin");

            Destroy(gameObject, 0.5f);

            
        }
    }
   
}
