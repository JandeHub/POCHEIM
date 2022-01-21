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

   

    private Animator _anim;
    private DazedSystem _dazed;
    

    //public int died { get; private set; }

    public event Action OnDie = delegate { };

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _dazed = GetComponent<DazedSystem>();
        
    }
    void Start()
    {
        currentHealth = maxHealth;

    }
    public void ReduceHealthEnemy(int damage)
    {
        _dazed.dazedTime = _dazed.startdazedTime;
        currentHealth -= damage;

        _anim.SetTrigger("hurt");
        if(currentHealth <= 0)
        {
            OnDie();
        }
    }

    public void ReduceHealthPlayer(int damage)
    {
        _anim.SetTrigger("hurt");
        if (currentHealth <= 0)
        {
            OnDie();
        }
    }

    

}
