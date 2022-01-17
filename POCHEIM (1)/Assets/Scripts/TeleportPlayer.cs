using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{

    private PlayerMovment _player;

    public event Action PortalEffect = delegate { };

    private void Start()
    {
        _player = GetComponent<PlayerMovment>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //other.GetComponent<Rigidbody2D>().gravityScale = 0;
        new WaitForSeconds(10);
        SceneManager.LoadScene("Game");
    }


}
