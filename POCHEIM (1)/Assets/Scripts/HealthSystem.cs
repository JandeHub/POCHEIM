using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    private float dazedTime;
    public float startdazedTime;

    private Animator _anim;
    private EnemySystem _enemySystem;

    //public int died { get; private set; }

    public event Action OnDie = delegate { };
    void Start()
    {
        currentHealth = maxHealth;

        _anim = GetComponent<Animator>();
        _enemySystem = GetComponent<EnemySystem>();
    
    }
   
    void Update()
    {
        if(dazedTime <= 0)
        {
            _enemySystem.speed = 2;
        }
        else
        {
            _enemySystem.speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }
    public void ReduceHealth(int damage)
    {
        dazedTime = startdazedTime;
        currentHealth -= damage;

        _anim.SetTrigger("hurt");
        if(currentHealth <= 0)
        {
            OnDie();
        }
    }

    

}
