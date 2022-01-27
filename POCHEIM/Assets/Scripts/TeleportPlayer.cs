using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField]
    private float seconds;

    private Animator _anim;
    private PlayerMovment _player;


    public event Action PortalEffect = delegate { };

    private void Start()
    {
        _player = GetComponent<PlayerMovment>();
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        _anim.SetTrigger("Change");
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(sceneIndex);
    }


}
