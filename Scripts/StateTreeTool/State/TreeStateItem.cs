using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateTreeTool
{
    public class TreeItem : ITreeItem
    {
        private ITreeItem[] _children;

        private ITreeItem _parent;

        private int _childFilledCount;

        public TreeItem(int childCount)
        {
            _children = new ITreeItem[childCount];
            _childFilledCount = 0;
        }

        public void AddChild(ITreeItem item)
        {
            _children[_childFilledCount++] = item;
        }

        public ITreeItem GetChild(int index)
        {
            return _children[index];
        }

        public ITreeItem[] GetChildren()
        {
            return _children;
        }

        public ITreeItem GetParent()
        {
            return _parent;
        }

        public void SetParent(ITreeItem item)
        {
            _parent = item;
        }
    }
}