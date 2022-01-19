using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackgound : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHoriontalLength;

    void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        groundHoriontalLength = groundCollider.size.x;
    }

    void Update()
    {
        if(transform.position.x < -groundHoriontalLength)
        {
            RepositionBackground();
        }
    }
    
    void RepositionBackground()
    {
        transform.Translate(Vector2.right * groundHoriontalLength * 4);
    }
}
