using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float _velocity;
    [SerializeField]
    private float jumpSpeed;

    private float dashSpeed;
    private float dashTime;
  

    private bool doubleJump;
    

    private InputSystemKeyboard _input;
    private GroundSystemChecker _ground;
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sp;



    void Start()
    {
        _input = GetComponent<InputSystemKeyboard>();
        _rb = GetComponent<Rigidbody2D>();
        _ground = GetComponent<GroundSystemChecker>();
        _anim = GetComponent<Animator>();
        _sp = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        

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
            else if(doubleJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed * 1.25f);
                _anim.SetTrigger("doubleJump");

                doubleJump = false;
            }
            
        }
        //DobleSalto
        if(_ground.isGrounded)
        {
            doubleJump = true;
        }
       



        
    }

}
