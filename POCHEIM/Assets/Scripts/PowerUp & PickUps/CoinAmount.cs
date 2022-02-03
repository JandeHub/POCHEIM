using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmount : MonoBehaviour
{
    public float amount;
    public Text amountText;

    public static CoinAmount _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        //amountText.text = " X " + amount.ToString();
    }
    public void Money(float moneyNumber)
    {
        /*amount += moneyNumber;

        amountText.text = " X " + amount.ToString();*/
    }
}
