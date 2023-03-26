using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateTreeTool
{
    internal interface IState
    {
        void Enter();       //可能要考虑入参

        void Update();

        void Exit();
    }
}

