using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SystemEnemyRangeAttack : MonoBehaviour
{
    private Animator _anim;
    private WeaponSystemCooldown _cooldown;
    private HealthSystem _health;

    
    [SerializeField]
    private float shootingRange;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletPlace;
   

    [SerializeField]
    private LayerMask player;

    void OnEnable()
    {
        GetComponent<KotSystem>().OnAttack += canAttack;

    }

    void OnDisable()
    {
        GetComponent<KotSystem>().OnAttack -= canAttack;
    }

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _cooldown = GetComponent<WeaponSystemCooldown>();
        _health = GameObject.Find("Player").GetComponent<HealthSystem>();
    }

    void canAttack()
    {
        if (!DebugModes.debugPlayerMode)
        {
            if (!_cooldown.cooling)
            {
                if (GetComponent<KotSystem>().distancePlayer <= shootingRange)
                {
                    _anim.SetTrigger("attackRange");
                    _cooldown.cooling = true;

                    Instantiate(bullet, bulletPlace.transform.position, Quaternion.identity);
                }


            }
        }
    }

   

    void OnDrawGizmos()
    {
        if (DebugModes.debugMode)
        {
           Gizmos.DrawWireSphere(transform.position, shootingRange);
        }
        
    }
}
