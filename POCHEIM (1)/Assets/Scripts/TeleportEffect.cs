using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeleportEffect : MonoBehaviour
{
    private PlayerMovment _player;

    void OnEnable()
    {
        GetComponent<TeleportPlayer>().PortalEffect += onTeleport;

    }

    void OnDisable()
    {
        GetComponent<TeleportPlayer>().PortalEffect -= onTeleport;
    }

    private void Start()
    {
        _player = GetComponent<PlayerMovment>();
    }

    void onTeleport()
    {
        _player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
