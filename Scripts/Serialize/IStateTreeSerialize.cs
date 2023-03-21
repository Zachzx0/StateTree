using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 组件与外部序列化方法的接口
/// 
/// </summary>
public interface IStateTreeSerialize
{
    void Deserialize();

    void Serialize();
}

public interface IStream
{
    void Serialize();

    void Deserialize();
}

public interface ISerialize
{
    void WriteTo(IStream stream);

    void ReadFrom(IStream stream);
}