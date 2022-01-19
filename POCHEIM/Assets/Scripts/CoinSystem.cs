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

    void TakeCoin()
    {

        if(_audio == null)
        {
            Debug.LogError("Audio in Coin NULL");
        }

        Debug.Log("Coin conseguido");

        _audio.Play();
        coin.SetActive(false);
    }
}
