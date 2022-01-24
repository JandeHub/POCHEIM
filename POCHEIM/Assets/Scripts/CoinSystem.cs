using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    private AudioSource _audio;

    void OnEnable()
    {
        GetComponent<CollisionSystem>().OnTakeCoin += TakeCoin;
    }

    void OnDisable()
    {
        GetComponent<CollisionSystem>().OnTakeCoin -= TakeCoin;
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_audio == null)
        {
            Debug.LogError("Audio in Coin NULL");
        }
    }
    void TakeCoin()
    {
        
        Debug.Log("Coin conseguido");

        _audio.Play();
        coin.SetActive(false);
    }
}
