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
        GameObject smileEnemy = GameObject.Find("Smile");
        GameObject kotEnemy = GameObject.Find("Kot");
        if (dazedTime <= 0)
        {
            smileEnemy.GetComponent<SmileSystem>().speed = 2;
            kotEnemy.GetComponent<KotSystem>().speed = 2;
        }
        else
        {
            smileEnemy.GetComponent<SmileSystem>().speed = 0;
            kotEnemy.GetComponent<KotSystem>().speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }
}
