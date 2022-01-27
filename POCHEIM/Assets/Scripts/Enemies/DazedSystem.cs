using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DazedSystem : MonoBehaviour
{
    public float dazedTime { get; set; }
    public float startdazedTime { get; private set; }

    public Transform _smile; 
    public Transform _kot;

    void Start()
    {
        

        startdazedTime = 0.2f;
    }

    void Update()
    {
        

        if (_smile != null && _kot != null)
        {
            
            if (dazedTime <= 0)
            {
                _smile.GetComponent<SmileSystem>().speed = 2;
                _kot.GetComponent<KotSystem>().speed = 3;

            }
            else
            {
                _smile.GetComponent<SmileSystem>().speed = 0;
                _kot.GetComponent<KotSystem>().speed = 0;
                dazedTime -= Time.deltaTime;
            }

        }

        
    }

    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("Enemy") != null && GameObject.FindWithTag("Enemy2") != null)
        {
            _smile = GameObject.FindWithTag("Enemy").transform;
            _kot = GameObject.FindWithTag("Enemy2").transform;
        }
    }
}
