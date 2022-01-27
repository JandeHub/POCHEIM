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

        GameObject enemy2 = PoolingManager.Instance.GetPooledObject("Enemy2");
        int random2 = UnityEngine.Random.Range(0, 2);
        if (enemy2 != null)
        {
            enemy2.transform.position = positions[random2].position;
            enemy2.transform.rotation = positions[random2].rotation;
            yield return new WaitForSeconds(4.0f);
            enemy2.SetActive(true);
            StartCoroutine(GenerateMeteor());

        }
    }
}

