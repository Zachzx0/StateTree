using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateTreeTool
{
    internal abstract class StateBase : IState
    {
        protected Context ContextObject;

        public StateBase(Context @object)
        {
            ContextObject = @object;
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


        public State(Context context) : base(context)
        {
        }

        public TreeItem Tree { get; private set; }


        private bool _allTaskCompleteSymbol = false;

        protected override void OnEnter()
        {
            _allTaskCompleteSymbol = false;

            int taskCount = _tasks.Length;
            for (int i = 0; i < taskCount; i++)
            {
                _tasks[i].Start();
            }
        }

        protected override void OnExit()
        {
            int taskCount = _tasks.Length;
            for (int i = 0; i < taskCount; i++)
            {
                _tasks[i].Stop();
            }
        }

        protected override void OnUpdate()
        {
            bool allTaskComplete = false;
            int taskCount = _tasks.Length;
            for(int i = 0; i < taskCount; i++)
            {
                var task = _tasks[i];
                if (task != null && task.Running && !task.Complete)
                {
                    task.Update();
                    allTaskComplete = allTaskComplete && task.Complete; 
                }
            }

            bool needTriggerAllTaskComplete = !_allTaskCompleteSymbol && allTaskComplete;
            int transitionCount = _transitions.Length;
            for(int i = 0; i < transitionCount; i++)
            {
                var transition = _transitions[i];
                if (needTriggerAllTaskComplete)
                {
                    transition.StateComplete();

                    if (transition.Check())
                    {
                        ContextObject.StateRuntime.SwitchState(transition.)
                    }
                }
            }
        }
    }
}