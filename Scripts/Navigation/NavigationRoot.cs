using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CutstomNavGrid
{
    public Vector3 Root;

    public Vector3 Size;

    public Vector3 MaxPos
    {
        get
        {
            return Root + Size / 2;
        }
    }

    public Vector3 MaxDownPos
    {
        get
        {
            return MaxPos + new Vector3(0, -Size.y / 2, 0);
        }
    }
    public Vector3 MaxBackPos
    {
        get
        {
            return MaxPos + new Vector3(0, 0, -Size.z / 2);
        }
    }
    public Vector3 MaxBackDownPos
    {
        get
        {
            return MaxPos + new Vector3(0, -Size.y / 2, -Size.z / 2);
        }
    }

    public Vector3 MinPos
    {
        get
        {
            return Root - Size / 2;
        }
    }

    public Vector3 MinForwardPos
    {
        get
        {
            return MinPos + new Vector3(0, 0, Size.z / 2);
        }
    }

    public Vector3 MinUpPos
    {
        get
        {
            return MinPos + new Vector3(0, Size.y / 2, 0);
        }
    }


    public Vector3 MinUpForwardPos
    {
        get
        {
            return MinPos + new Vector3(0, Size.y / 2, Size.z / 2);
        }
    }
}


public class NavigationRoot : MonoBehaviour
{

    public CutstomNavGrid Grid;

    public Vector3 Root { get { return transform.position; } }

   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
