using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTreeTool
{
    internal class Context
    {
        public StateRunTime StateRuntime { get; set; }
    }

    /// <summary>
    /// 通过序列化数据创建对象
    /// 或者手动调用State对象
    /// </summary>
    public class StateRunTime : SerializeData
    {

        public StateRunTime()
        {

        }

        internal Context ContextObejct;

        internal State Root;

        private IState _current;
        private IState _last;

        internal Dictionary<int , IState> IdToState = new Dictionary<int, IState>();

        public void Start(int specifyId)
        {
            SwitchState(IdToState[specifyId]);
        }

        internal void SwitchState(IState next)
        {
            if (_current != null) _current.Exit();
            _last = _current;
            _current = next;
            _current.Enter();
        }

        public void Update(long time)      //浮点数暂时都乘1000变成long
        {
            if (_current != null) _current.Update();
        }




        protected override void WriteToImp(IStream stream)
        {
            
        }

        protected override void ReadFromImp(IStream stream)
        {
            //需要设计出参数封装，封装基本的参数
            // ParamString
            // ParamFloat(long 存储)
            // ParamLong
            // ParamInt
            // ParamByte
            // ParamLong


            //先Read所有实例
            //----Read Condition
            //----Read Transition
            //----ReadTask
            //----ReadState


            //序列化的逻辑

            //对象为空 写0
            //


            ContextObejct = new Context();
            ContextObejct.StateRuntime = this;
        }
    }
}
