using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateTreeTool
{
    public interface IState
    {
        void Enter();       //可能要考虑入参

        void Update();

        void Exit();
    }

    public interface ITreeItem
    {
        void SetParent(ITreeItem item);

        void AddChild(ITreeItem item);

        ITreeItem GetParent();

        ITreeItem[] GetChildren();

        ITreeItem GetChild(int index);

    }

    public abstract class StateBase : IState
    {
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
}

