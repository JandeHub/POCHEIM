using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    
    public int index;
    public Transform gameManager;
    public GameObject DialogCanvas;


    GameManager gameManagerC;


    void Start()
    {
        gameManagerC = gameManager.GetComponent<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        DialogCanvas.SetActive(true);
        gameManagerC.OnTriggerDialog(index);

        Destroy(gameObject, 3f);



    } 
    void FixedUpdate()
    {

        if(DebugModes.debugDialogs)
        {
            DialogCanvas.SetActive(true);
        }
    }
}
