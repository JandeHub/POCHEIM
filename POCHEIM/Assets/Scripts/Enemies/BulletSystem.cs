using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public Transform _target; 

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private int damage;

    private Rigidbody2D _rb;
    private Animator _anim;

    void OnEnable()
    {
        GetComponent<CollisionSystem>().DamageBullet -= bulletDamage;

    }

    void OnDisable()
    {
        GetComponent<CollisionSystem>().DamageBullet -= bulletDamage;
    }

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            _target = GameObject.FindWithTag("Player").transform;
        }

        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        

        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        _rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        if (_target != null)
        {
            if (transform.position.x < _target.position.x)
            {
                transform.localScale = new Vector2(-2.5f, 2.5f);
            }
            else
            {
                transform.localScale = new Vector2(2.5f, 2.5f);
            }
        }


    }

    private void Update()
    {
        Destroy(gameObject, 3);
    }


   void OnTriggerEnter2D (Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hitted");
            collision.GetComponent<HealthSystem>().ReduceHealthPlayer(damage);

            _anim.SetTrigger("destroy");
            Destroy(gameObject, 1);

        }

    }

    void bulletDamage()
    {
        Debug.Log("Hitted");
    }
    




}
