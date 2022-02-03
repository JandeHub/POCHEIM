using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public int index;
    public Transform gameManager;
    public GameObject DialogCanvas;

    public float secondsDialog = 5f;


    GameManager gameManagerC;


    void Start()
    {
        gameManagerC = gameManager.GetComponent<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        DialogCanvas.SetActive(true);
        gameManagerC.OnTriggerDialog(index);

        Destroy(gameObject, 4f);
       
    } 
    void FixedUpdate()
    {
        if(secondsDialog <= 0f)
        {
            DialogCanvas.SetActive(false);
            
        }
        else
        {
            secondsDialog -= Time.deltaTime;
        }

        if(DebugModes.debugDialogs)
        {
            DialogCanvas.SetActive(true);
        }
    }
}
