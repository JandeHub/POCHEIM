using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] positions;
    private PooledItems pooling;



    void Start()
    {
        StartCoroutine(GenerateMeteor());
    }

    IEnumerator GenerateMeteor()
    {
        GameObject enemy = PoolingManager.Instance.GetPooledObject("Enemy");
        int random = UnityEngine.Random.Range(0, 2);
        if (enemy != null)
        {
            enemy.transform.position = positions[random].position;
            enemy.transform.rotation = positions[random].rotation;
            yield return new WaitForSeconds(4.0f);
            enemy.SetActive(true);
            StartCoroutine(GenerateMeteor());

        }
    }
}

