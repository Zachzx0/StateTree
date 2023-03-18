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

    public abstract class State : IState
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

    public abstract class TreeStateItem : State, ITreeItem
    {
        public void AddChild(ITreeItem item)
        {
            throw new System.NotImplementedException();
        }

        public ITreeItem GetChild(int index)
        {
            throw new System.NotImplementedException();
        }

        public ITreeItem[] GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public ITreeItem GetParent()
        {
            throw new System.NotImplementedException();
        }

        public void SetParent(ITreeItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}

