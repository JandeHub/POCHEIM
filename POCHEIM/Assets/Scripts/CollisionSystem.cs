using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSystem : MonoBehaviour
{
    public event Action OnTakeCoin = delegate { };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTakeCoin();
    }
}


