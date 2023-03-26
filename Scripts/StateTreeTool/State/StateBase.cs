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
    /// 状态
    /// </summary>
    internal class State : StateBase
    {

        //进入条件(Obsolete)
        //Task
        //      Enter执行的Task
        //      Update执行的task
        //      Leave执行的Task
        //TransitionTo

        private ITask[] _tasks = null;                  //任务作为状态的每个子节点

        private StateTransition[] _transitions = null;  //其他状态的过渡


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