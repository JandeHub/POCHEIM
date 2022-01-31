using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
    public class WaveAction
    {
        public string name;
        public float delay;
        public Transform enemyPrefab;
        public int spawnCount;
        public string message;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public List<WaveAction> actions;
    }


public class WaveGenerator : MonoBehaviour
{
    public float difficultyFactor = 0.9f;
    private float _delayFactor = 1.0f;

    public Text waveText;
    public Transform[] positions;
    public List<Wave> waves;
    private Wave _currentWave;
    public Wave CurrentWave { get { return _currentWave; } }
    public Vector3 spawnValues;


    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        _delayFactor = 1.0f;

        while(true)
        {
            foreach(Wave W in waves)
            {
                _currentWave = W;
                foreach(WaveAction Action in W.actions)
                {
                    if (Action.delay > 0)
                        yield return new WaitForSeconds(Action.delay * _delayFactor);
                    if(Action.message != "")
                    {
                        waveText.text = Action.message.ToString();
                    }

                    
                    
                    if(Action.enemyPrefab != null && Action.spawnCount > 0)
                    {
                        for(int i = 0; i < Action.spawnCount; i++)
                        {
                            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                            Vector3 spawnPosition2 = new Vector3(-spawnValues.x, spawnValues.y, spawnValues.z);
                            Quaternion spawnRotation = Quaternion.identity;
                            Instantiate(Action.enemyPrefab, spawnPosition, spawnRotation);
                            Instantiate(Action.enemyPrefab, spawnPosition2, spawnRotation);


                        }
                    }
                }
                yield return null;
            }
            _delayFactor *= difficultyFactor;
            yield return null;
        }
    }
}
