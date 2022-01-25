using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazedSystem : MonoBehaviour
{
    public float dazedTime { get; set; }
    public float startdazedTime { get; private set; }

    private SmileSystem _smileSystem;
    private KotSystem _kotSystem;

    void Start()
    {
        _smileSystem = GetComponent<SmileSystem>();
        _kotSystem = GetComponent<KotSystem>();
        startdazedTime = 0.2f;
    }

    void Update()
    {
      
        if (dazedTime <= 0)
        {
            GameObject.Find("Smile").GetComponent<SmileSystem>().speed = 2;
            GameObject.Find("Kot").GetComponent<KotSystem>().speed = 2;
        }
        else
        {
            GameObject.Find("Smile").GetComponent<SmileSystem>().speed = 0;
            GameObject.Find("Kot").GetComponent<KotSystem>().speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }
}
