using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TransformacionesEstrellas : MonoBehaviour
{
    public Mesh model;
    public Material mEstrellas;

    public int numEstrellas;
    public float anchoEstrellas;
    public float altoEstrellas;
    public float distanciaEstrellas;

    private Vector3[] posicionesEstrellas;
    private float[] escalasEstrellas;

    private Matrix4x4[] matricesEstrellas;
    private Matrix4x4[] matricesEstrellasEscala;
    private float escalaEstrellas;
    


    void Start()
    {
        posicionesEstrellas = new Vector3[numEstrellas];
        matricesEstrellas = new Matrix4x4[numEstrellas];
        matricesEstrellasEscala = new Matrix4x4[numEstrellas];

        escalasEstrellas = new float[numEstrellas];

        for(int i = 0; i < numEstrellas; i++)
        {
            posicionesEstrellas[i] = new Vector3(Random.Range(-anchoEstrellas / 2, anchoEstrellas / 2), Random.Range(-altoEstrellas / 2, altoEstrellas / 2),
                                                    distanciaEstrellas);

            matricesEstrellas[i] = Matrix4x4.Translate(posicionesEstrellas[i]);
            escalasEstrellas[i] = Random.Range(1f, 2.0f);
        }

    }

    
    void Update()
    {
        for (int i = 0; i < numEstrellas; i++)
        {
            float s = escalasEstrellas[i] * escalaEstrellas;
            matricesEstrellasEscala[i] = matricesEstrellas[i] * Matrix4x4.Scale(new Vector3(s, s, 1));
        }

        Graphics.DrawMeshInstanced(model, 0, mEstrellas, matricesEstrellasEscala);

    }
}
