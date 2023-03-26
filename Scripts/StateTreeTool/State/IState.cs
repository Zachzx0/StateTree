using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateTreeTool
{
    internal interface IState
    {
        void Enter();       //����Ҫ�������

        void Update();

        void Exit();
    }
}

