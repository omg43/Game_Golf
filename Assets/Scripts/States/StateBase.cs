using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public abstract class StateBase: MonoBehaviour
    {
        public abstract void Initialize(GameStateMashine gameStateMashine);
        public abstract void Enter();
        public abstract void Exit();
    }
}
