using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM //Utilizamos el namespace para no confundir la clase Action de unity
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(Controller controller);

    }

}
