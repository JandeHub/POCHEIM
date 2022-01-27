using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    public float currentHealth;

    private Animator _anim;
    private DazedSystem _dazed;
    private HealthSystemUI _healthUI;
    

    //public int died { get; private set; }

    public event Action OnDie = delegate { };
    public event Action<float> MaxHealth = delegate { };
    public event Action<float> UpdateHealth = delegate { };

    public event Action JumpGameOver = delegate { };


    void Start()
    {
        _anim = GetComponent<Animator>();
        _dazed = GetComponent<DazedSystem>();
        _healthUI = GetComponent<HealthSystemUI>();


        currentHealth = maxHealth;
        MaxHealth(maxHealth);

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

        FindObjectOfType<AudioManager>().Play("HurtPlayer");
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            JumpGameOver();
        }
    }

    void FixedUpdate()
    {
        UpdateHealth(currentHealth);
        
    }
    

    

}
