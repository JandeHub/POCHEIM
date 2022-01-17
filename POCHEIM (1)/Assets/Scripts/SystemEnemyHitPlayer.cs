using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SystemEnemyHitPlayer : MonoBehaviour
{
    private Animator _anim;
    private WeaponSystemCooldown _cooldown;
    private HealthSystem _health;

    [SerializeField]
    private Transform attackHitbox;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private int damage;

    [SerializeField]
    private LayerMask player;

    void OnEnable()
    {
        GetComponent<EnemySystem>().OnAttack += canAttack;

    }

    void OnDisable()
    {
        GetComponent<EnemySystem>().OnAttack -= canAttack;

    }

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _cooldown = GetComponent<WeaponSystemCooldown>();
        _health = GetComponent<HealthSystem>();
        
    }


    void canAttack()
    {
        if (!_cooldown.cooling)
        {
            _anim.SetTrigger("attackMelee");
            _cooldown.cooling = true;

          

            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackHitbox.position, attackRange, player);

            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<HealthSystem>().ReduceHealth(damage);
                Debug.Log("Hited");
            }

        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackHitbox == null)
            return;

        Gizmos.DrawWireSphere(attackHitbox.position, attackRange);
    }
}
