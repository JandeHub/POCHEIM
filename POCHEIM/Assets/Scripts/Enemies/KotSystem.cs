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

    public float distancePlayer { get; private set; }

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

        distancePlayer = Vector2.Distance(transform.position, player.position);

        if (distancePlayer > 4 && Mathf.Abs(distancePlayer) > 2)
        {
            FollowPlayer();
        }
        else if (Mathf.Abs(distancePlayer) > agroDistance)
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
                    transform.localScale = new Vector2(-3f, 3f);
                }
                else
                {
                    transform.localScale = new Vector2(3f, 3f);
                }

                transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemySpeed * Time.deltaTime);
            }
        }
    }
}
