using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlayerHitEnemy : MonoBehaviour
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
    private LayerMask enemies;
    
    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnPunch += canPunch;
       
    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnPunch -= canPunch;
       
    }
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _cooldown = GetComponent<WeaponSystemCooldown>();
        _health = GetComponent<HealthSystem>();
    }
   

   

    void canPunch()
    {
        if (!_cooldown.cooling)
        {
               
            FindObjectOfType<AudioManager>().Play("SwordSlash");
            _anim.SetTrigger("0");


            _cooldown.cooling = true;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackHitbox.position, attackRange, enemies);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<HealthSystem>().ReduceHealthEnemy(damage);
            }
            

        }
       


    }

    void OnDrawGizmos()
    {
        
        if (DebugModes.debugMode)
        {
            if (attackHitbox == null)
            return;

            Gizmos.DrawWireSphere(attackHitbox.position, attackRange);
        }
        
    }
}
