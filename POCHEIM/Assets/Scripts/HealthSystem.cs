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
    private SmileSystem _smileSystem;

    //public int died { get; private set; }

    public event Action OnDie = delegate { };

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _smileSystem = GetComponent<SmileSystem>();
    }
    void Start()
    {
        currentHealth = maxHealth;

        


    }
   
    void Update()
    {
        if(dazedTime <= 0)
        {
            GetComponent<SmileSystem>().speed = 2;
        }
        else
        {
            GetComponent<SmileSystem>().speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }
    public void ReduceHealthEnemy(int damage)
    {
        dazedTime = startdazedTime;
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
