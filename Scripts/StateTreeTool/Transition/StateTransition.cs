using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTreeTool
{
    /// <summary>
    /// ——————该结构定义了状态迁移
    /// ——————状态迁移配置：触发+目标状态
    /// ————————————触发：
    /// ——————————————————类型：
    /// ————————————————————————OnStateComplete（所有任务都结束）
    /// ————————————————————————OnTick（根据条件切出）
    /// ————————————————————————[待定]OnEvent（根据事件切出）
    ///         
    /// </summary>
    /// 

    public enum EStateTransitionType
    {
        OnStateComplete,
        OnTick,
        OnEvent
    }
    internal class StateTransition
    {
        //TransitionTo

        //Trigger:OnStateComplete, OnStateSucc,OnStateFailed, OnTick, OnEvent

        //Condition

        //public bool Update()
        //{
        //    //如果StateComplete，就调用Transition的StateComplete
        //    //遍历check
        //}
        
    }

    internal interface ITransition
    {
        EStateTransitionType StateTransitionType { get; }

        bool Init { get; }

        void StateComplete();

        bool Check();
    }

    internal abstract class TransitionBase : ITransition
    {
        private EStateTransitionType _stateTransitionType = EStateTransitionType.OnStateComplete;
        public EStateTransitionType StateTransitionType => _stateTransitionType;


        private bool _init = false;
        public bool Init => _init;

        protected bool stateComplete = false;

        public TransitionBase(EStateTransitionType type) { _stateTransitionType = type; }

        public abstract bool Check();

        public void StateComplete()
        {
            stateComplete = true;
        }
    }

    internal class TransitionWhenStateComplete : ITransition
    {
        public EStateTransitionType StateTransitionType => throw new NotImplementedException();

        public bool Init => throw new NotImplementedException();

        public bool Check()
        {
            throw new NotImplementedException();
        }

        public void StateComplete()
        {
            throw new NotImplementedException();
        }
    }
}
