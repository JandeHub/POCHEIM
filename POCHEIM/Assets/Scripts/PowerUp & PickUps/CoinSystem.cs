using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{

    private SpriteRenderer _sp;
    private BDInventory _inv;



    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        _inv = GetComponent<BDInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _sp.enabled = false;

            CoinAmount._instance.Money(1f);
            FindObjectOfType<AudioManager>().Play("TakeCoin");
            
            Destroy(gameObject, 0.5f);
            GameObject.Find("DBase").GetComponent<BDInventory>().AddCoins(1);

            
        }
    }
   
}
