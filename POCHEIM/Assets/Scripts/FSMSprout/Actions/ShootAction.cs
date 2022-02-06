using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Sprout/Actions/Shoot")]
public class ShootAction : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);

        controller.SetAnimation("shoot", true); 
    }
}

