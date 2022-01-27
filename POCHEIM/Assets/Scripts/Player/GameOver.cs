using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public GameObject gameOver;


    private HealthSystem _health;


    void OnEnable()
    {
        GetComponent<HealthSystem>().JumpGameOver += GameOverUI;

    }

    void OnDisable()
    {
        GetComponent<HealthSystem>().JumpGameOver -= GameOverUI;

    }
    void Start()
    {
        _health = GetComponent<HealthSystem>();

    }

    void GameOverUI()
    {
        gameOver.SetActive(true);
        Destroy(gameObject);

    }
}
