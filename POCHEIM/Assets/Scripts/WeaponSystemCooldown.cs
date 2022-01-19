using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystemCooldown : MonoBehaviour
{
    
    public float cooldownAttack;

    public float cooldownCount { get; set; }

    public bool cooling { get; set; }


    void Start()
    {
        cooling = false;

        cooldownCount = cooldownAttack;
    }

    void Update()
    {
        if (cooling)
        {
            cooldownCount -= Time.deltaTime;

            if (cooldownCount <= 0)
            {
                cooling = false;
                cooldownCount = cooldownAttack;
            }
        }
    }
    

}
