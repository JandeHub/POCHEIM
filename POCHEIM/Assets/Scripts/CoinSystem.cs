using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    void OnEnable()
    {
        GetComponent<CollisionSystem>().OnTakeCoin += TakeCoin;
    }

    void OnDisable()
    {
        GetComponent<CollisionSystem>().OnTakeCoin -= TakeCoin;
    }

    void TakeCoin()
    {
        Debug.Log("Coin conseguido");
        coin.SetActive(false);
    }
}
