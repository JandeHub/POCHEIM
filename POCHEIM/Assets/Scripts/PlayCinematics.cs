using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayCinematics : MonoBehaviour
{

    public PlayableDirector timeLine;


    /*void OnEnable()
    {
        GetComponent<CollisionSystem>().OnCinematic += StartTimeLine;
    }

    void OnDisable()
    {
        GetComponent<CollisionSystem>().OnCinematic -= StartTimeLine;
    }*/

    void Start()
    {
        timeLine = GetComponent<PlayableDirector>();
       
    }
    
  

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            timeLine.Play();
        }
        
    }

    /*private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeLine.Stop();
        }
    }*/



}
