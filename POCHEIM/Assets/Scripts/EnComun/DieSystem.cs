using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSystem : MonoBehaviour
{
    private Animator _anim;

    public bool dead { get; private set; }

    void OnEnable()
    {
        GetComponent<HealthSystem>().OnDie += Die;
    }

    void OnDisable()
    {
        GetComponent<HealthSystem>().OnDie -= Die;
    }

    void Start()
    {
        _anim = GetComponent<Animator>();
        
        dead = false;
    }

    void Die()
    {
        Debug.Log("Enemy died");

        dead = true;
        _anim.SetBool("dead", true);

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2);
        this.enabled = true;
        


    }
}
