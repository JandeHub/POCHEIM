using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Sprout/Decisions/HealthDecision")]
public class HealthDecision : FSM.Decision
{
    public int healthlimitmin, healthlimitmax;
    public override bool Decide(Controller controller)
    {
        float h = controller.GetCurrentHealth();
        bool t = (h < healthlimitmin && h > healthlimitmax);

        return t;
    }
}
