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
    internal class StateTransition: ITransition
    {
        public int TransitionTo { get; private set; }

        private ITransition _transitionImp;

        public StateTransition(int toState, EStateTransitionType tranisitonType)
        {
            TransitionTo = toState;
            _transitionImp = TransitionFactory.CreateTransition(tranisitonType);
        }

        public bool Init => _transitionImp.Init;

        public bool Check()
        {
            return _transitionImp.Init && _transitionImp.Check();
        }

        public void StateComplete()
        {
            _transitionImp.StateComplete();
        }
    }

    internal interface ITransition
    {
        bool Init { get; }

        void StateComplete();

        bool Check();
    }

    internal abstract class TransitionBase : ITransition
    {
        private EStateTransitionType _stateTransitionType = EStateTransitionType.OnStateComplete;
        public EStateTransitionType StateTransitionType { get { return _stateTransitionType; } }


        private bool _init = false;
        public bool Init => _init;

        protected bool stateComplete = false;

        protected ICondition[] conditions;

        public TransitionBase(EStateTransitionType type) { _stateTransitionType = type; }

        public abstract bool Check();

        public void StateComplete()
        {
            stateComplete = true;
        }

        protected bool CheckCondition()
        {
            bool result = true;
            int condCount = conditions.Length;
            for (int i = 0; i < condCount; i++)
            {
                if (!conditions[i].Check())
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }

    internal class TransitionWhenStateComplete : TransitionBase
    {
        public TransitionWhenStateComplete(EStateTransitionType type) : base(type)
        {
        }

        public override bool Check()
        {
            if (stateComplete)
            {
                return CheckCondition();
            }

            return false;
        }
    }

    internal class TransitionTick : TransitionBase
    {
        public TransitionTick(EStateTransitionType type) : base(type)
        {
        }

        public override bool Check()
        {
            return CheckCondition();
        }
    }

    internal static class TransitionFactory
    {
        public static ITransition CreateTransition(EStateTransitionType type)
        {
            switch (type)
            {
                case EStateTransitionType.OnTick:
                    return new TransitionTick(type);
                case EStateTransitionType.OnStateComplete:
                    return new TransitionWhenStateComplete(type);
                default: break;
            }
            return null;
        }
    }
}
