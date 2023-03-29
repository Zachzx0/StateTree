using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StateTreeTool
{
    /// <summary>
    /// 任务的定义：
    /// ——————任务跟随状态的生命周期
    /// ——————一个状态对应多个任务
    /// ——————————————————如果多个任务都执行完了，会触发状态的OnStateComplete。
    /// —————————————————— 状态可以判断是否配置任务结束切出决定自己的状态
    /// ——————任务有自己的Update方法
    /// ——————任务可以访问状态以及状态运行时的当前帧预计算数据
    /// ——————与UEStateTree不同的是，该任务不是在状态内阻塞执行，而是顺序执行。且不会根据任务结果影响状态切换
    /// 
    /// </summary>
    internal interface ITask
    {
        bool Running { get; }

        bool Complete { get; }
        void Start();

        void Update();
        void Stop();
    }
}
