using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateTreeTool
{
    internal abstract class StateBase : IState
    {
        protected IStateRuntime runtime;

        public StateBase(IStateRuntime stateRuntime)
        {
            this.runtime = stateRuntime;
        }

        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        public void Update()
        {
            OnUpdate();
        }

        protected abstract void OnEnter();
        protected abstract void OnUpdate();
        protected abstract void OnExit();

    }


    /// <summary>
    /// ״̬
    /// </summary>
    internal class State : StateBase
    {

        //��������(Obsolete)
        //Task
        //      Enterִ�е�Task
        //      Updateִ�е�task
        //      Leaveִ�е�Task
        //TransitionTo

        private ITask[] _tasks = null;                  //������Ϊ״̬��ÿ���ӽڵ�

        private StateTransition[] _transitions = null;  //����״̬�Ĺ���


        public State(IStateRuntime stateRuntime) : base(stateRuntime)
        {
        }

        public TreeItem Tree { get; private set; }

        protected override void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnExit()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdate()
        {
            int taskCount = _tasks.Length;
            for(int i = 0; i < taskCount; i++)
            {
                _tasks[i].Update();
            }
        }
    }
}