using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private GameObject dashEffect;

    [SerializeField]
    private float _velocity;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float startDashCooldown;
    [SerializeField]
    private float dashTime;

    private float dashCooldown;
    private Vector2 dashDiretion;
    private bool canDash;
    private bool isDashing;
    private bool doubleJump;




    private InputSystemKeyboard _input;
    private GroundSystemChecker _ground;
    private Rigidbody2D _rb;
    private Animator _anim;
    private TrailRenderer _trail;
    private SpriteRenderer _sp;




    void Start()
    {
        _input = GetComponent<InputSystemKeyboard>();
        _rb = GetComponent<Rigidbody2D>();
        _ground = GetComponent<GroundSystemChecker>();
        _anim = GetComponent<Animator>();
        _trail = GetComponent<TrailRenderer>();
        _sp = GetComponent<SpriteRenderer>();

        dashCooldown = startDashCooldown;
        canDash = true;


    }


    void Update()
    {

        //Movimiento
        _rb.velocity = new Vector2(_input.hor * _velocity, _rb.velocity.y);

        if (_input.hor > 0)
        {

            _anim.SetBool("run", true);
            transform.localScale = new Vector2(3.5f, 3.5f);
        }

        else
            if (_input.hor < 0)
        {
            _anim.SetBool("run", true);
            transform.localScale = new Vector2(-3.5f, 3.5f);

        }
        if (_input.hor == 0)
        {
            _anim.SetBool("run", false);

        }

        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_ground.isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
                _anim.SetTrigger("jump");
            }
            else if (doubleJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed * 1.25f);
                _anim.SetTrigger("doubleJump");

                doubleJump = false;
            }

        }
        //DobleSalto
        if (_ground.isGrounded)
        {
            doubleJump = true;
        }


        //Dash

        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.K) && canDash && dashCooldown <= 0)
        {
            isDashing = true;
            canDash = false;
            _trail.emitting = true;
            dashDiretion = new Vector2(_input.hor, 0);

            if (dashDiretion == Vector2.zero)
            {
                dashDiretion = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());


        }

        if (isDashing)
        {
            _rb.velocity = dashDiretion.normalized * dashSpeed;
            return;
        }

        if (_ground.isGrounded)
        {
            canDash = true;
        }

        IEnumerator StopDashing()
        {
            yield return new WaitForSeconds(dashTime);
            _trail.emitting = false;
            isDashing = false;
            dashCooldown = startDashCooldown;
        }



    }


}
