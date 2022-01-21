using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazedSystem : MonoBehaviour
{
    public float dazedTime { get; set; }
    
    
    public float startdazedTime { get; private set; }

    private SmileSystem _smileSystem;

    void Start()
    {
        _smileSystem = GetComponent<SmileSystem>();
        startdazedTime = 0.2f;
    }

    void Update()
    {
        if (dazedTime <= 0)
        {
            _smileSystem.speed = 2;
        }
        else
        {
            _smileSystem.speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }
}
