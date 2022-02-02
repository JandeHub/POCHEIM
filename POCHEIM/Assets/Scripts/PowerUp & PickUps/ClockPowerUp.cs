using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPowerUp : MonoBehaviour
{
    public float amount;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
  
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.deltaTime * .02f;
    }

    // Update is called once per frame
    void Update()
    {
        SlowMo.Activate(amount, duration);

    }
}
