using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmileSystem : MonoBehaviour
{
    public Transform player;

    //[SerializeField]
    public float speed { get; set; }

    public float enemySpeed;

    [SerializeField]
    private int agroDistance;


    private Rigidbody2D _rb;
    private DieSystem _dieSystem;
    

    public event Action OnAttack = delegate { };

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        _rb = GetComponent<Rigidbody2D>();
        _dieSystem = GetComponent<DieSystem>();
        
    }

    void Update()
    {
        enemySpeed = speed;

        float distancePlayer = Vector2.Distance(transform.position, player.position);

        if(distancePlayer > 1.0f && Mathf.Abs(distancePlayer) > 2)
        {
            FollowPlayer();
        }
        else if(Mathf.Abs(distancePlayer) > agroDistance)
        {
            if (!_dieSystem.dead)
            {
                OnAttack();
            }
        }

    }

    void FollowPlayer()
    {
        if (!_dieSystem.dead)
        {
            if (player != null)
            {
                if (transform.position.x < player.position.x)
                {
                    _rb.velocity = new Vector2(enemySpeed, 0);
                    transform.localScale = new Vector2(-4f, 4f);
                }

                else
                {
                    _rb.velocity = new Vector2(-enemySpeed, 0);
                    transform.localScale = new Vector2(4f, 4f);
                }
            }
        }
    }
}
