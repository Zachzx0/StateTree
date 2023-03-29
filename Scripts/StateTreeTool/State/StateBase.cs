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