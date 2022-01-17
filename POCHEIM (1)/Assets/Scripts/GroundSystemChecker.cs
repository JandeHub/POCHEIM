using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSystemChecker : MonoBehaviour
{
    public Transform groundChecker;
    public float radius;
    public LayerMask groundMask;

    public bool isGrounded { get; private set; }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);
    }
}
