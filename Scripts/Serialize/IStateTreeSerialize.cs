using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ⲿ���л������Ľӿ�
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