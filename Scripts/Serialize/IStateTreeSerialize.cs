using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ⲿ���л������Ľӿ�
/// 
/// </summary>
public interface IStream
{
    void WriteByte();

    void WriteShort();

    void WriteInt();

    void WriteLong();

    void WriteFloat();

    void WriteDouble();

    void WriteString();

    byte ReadBytes();

    short ReadShort();

    int ReadInt();

    long ReadLong();

    float ReadFloat();

    double ReadDouble();

    string ReadString();
}
