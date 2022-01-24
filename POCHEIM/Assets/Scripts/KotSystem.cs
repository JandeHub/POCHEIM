using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KotSystem : MonoBehaviour
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

        _rb = GetComponent<Rigidbody2D>();
        _dieSystem = GetComponent<DieSystem>();

    }

    void Update()
    {
        enemySpeed = speed;

        float distancePlayer = Vector2.Distance(transform.position, player.position);

        if (distancePlayer > 1.0f && Mathf.Abs(distancePlayer) > 2)
        {
            FollowPlayer();
        }
        else if (Mathf.Abs(distancePlayer) > agroDistance)
        {
            OnAttack();
        }

    }

    void FollowPlayer()
    {
        if (!_dieSystem.dead)
        {
            if (transform.position.x < player.position.x)
            {
                _rb.velocity = new Vector2(enemySpeed, 0);
                transform.localScale = new Vector2(-3f, 3f);
            }

            else
            {
                _rb.velocity = new Vector2(-enemySpeed, 0);
                transform.localScale = new Vector2(3f, 3f);
            }
        }
    }
}
