using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateTreeTool
{
    public class FSM<StateType> where StateType : enum
    {
        private Dictionary<int, IState> _stateTypeToState = new Dictionary<int, IState>();

        public void Init()
        {

        }


        public void Tick()
        {

        }
    }
}
