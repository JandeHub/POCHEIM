using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audio;

    private SpriteRenderer _sp;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _sp.enabled = false;

            _audio.Play();

            Destroy(gameObject, 0.5f);

            
        }
    }
   
}
