using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemKeyboard : MonoBehaviour
{
    
    
    public float hor { get; private set; }
    public float ver { get; private set; }

    //Evento creado, se utiliza "delegate" para decir que esa linea de codigo es un evento
    public event Action OnPunch = delegate { };
    public event Action OnPause = delegate { };

    

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.J))
            OnPunch();

        else if (Input.GetKeyDown(KeyCode.Escape))
            OnPause();

   

        

    }
}
