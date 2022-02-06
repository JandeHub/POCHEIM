using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Sprout/Actions/Idle")]
public class IdleAction : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", true);

        controller.SetAnimation("shoot", false);
    }
}
