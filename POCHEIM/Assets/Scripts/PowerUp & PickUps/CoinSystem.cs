using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{

    private SpriteRenderer _sp;
    private DBManager _db;



    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        _db = GetComponent<DBManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _sp.enabled = false;

            //DBManager._instance.AddCoins(1);

            CoinAmount._instance.Money(1f);
            FindObjectOfType<AudioManager>().Play("TakeCoin");
            
            Destroy(gameObject);
            

            
        }
    }
   
}
