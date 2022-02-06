using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodWithRecursividad : MonoBehaviour
{
    public GameObject bloodPrefab;
    public Transform bloodOrigin;
    public float bloodScale;
    public float minimumBloodScale;


    public bool doAction { get; set; }



    void Update()
    {
        
        Vector3 position2 = new Vector3(Random.Range(-0.6f, 0.6f), Random.Range(0.4f, 0.7f), 0);
        Vector3 position3 = new Vector3(Random.Range(-0.6f, 0.6f), Random.Range(0.4f, 0.7f), 0);

  
        if (doAction)
        {
            GameObject go = GameObject.Find("Blood");
            if (go != null)
            {
                Destroy(go);
            }

            go = new GameObject("Blood");
            go.transform.position = Vector3.zero;

            
            
            GenerateBlood(go.transform, bloodOrigin.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)),
                    new Vector3(Random.Range(minimumBloodScale, bloodScale), Random.Range(minimumBloodScale, bloodScale),
                    Random.Range(minimumBloodScale, bloodScale)));

            GenerateBlood(go.transform, bloodOrigin.position + position2, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)),
                    new Vector3(Random.Range(minimumBloodScale, bloodScale), Random.Range(minimumBloodScale, bloodScale),
                    Random.Range(minimumBloodScale, bloodScale)));

            GenerateBlood(go.transform, bloodOrigin.position + position3, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)),
                    new Vector3(Random.Range(minimumBloodScale, bloodScale), Random.Range(minimumBloodScale, bloodScale),
                    Random.Range(minimumBloodScale, bloodScale)));


            doAction = false;

            Destroy(go, 0.5f);
            

           
        }

    }


    void GenerateBlood(Transform parent, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        
        GameObject go = Instantiate(bloodPrefab);
        go.transform.position = position;
        go.transform.rotation = rotation;
        go.transform.parent = parent;
        go.transform.localScale = scale;

        

       
            

            
            
            

        
        




    }
}
