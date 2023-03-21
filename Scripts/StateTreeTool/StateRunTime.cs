using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTreeTool
{


    /// <summary>
    /// 通过序列化数据创建对象
    /// 或者手动调用State对象
    /// </summary>
    public class StateRunTime : ISerialize
    {

        public StateRunTime()
        {

        }

        public State Root;

        private IState _current;
        private IState _last;

        public void SwitchState(IState next)
        {
            if (_current != null) _current.Exit();
            _last = _current;
            _current = next;
            _current.Enter();
        }

        public void Update(float time)      //float这种数据类型咋办，之后处理吧
        {
            if (_current != null) _current.Update();
        }





        public void WriteTo(IStream stream)
        {
            throw new NotImplementedException();
        }

        public void ReadFrom(IStream stream)
        {
            throw new NotImplementedException();
        }
    }
}
