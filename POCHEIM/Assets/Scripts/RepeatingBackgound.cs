using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackgound : MonoBehaviour
{
    private float length;
    private float startpos;

    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private float parallaxEffect;    
    

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (_camera.transform.position.x * (1 - parallaxEffect));
        float distance = (_camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;
    }
   
}
