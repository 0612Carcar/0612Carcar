using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIngleton<T> where T : class,new()
{
    private static T Inst;
    public static T GetT
    {
        get
        {
            if (Inst == null)
            {
                Inst = new T();
            }
            return Inst;
        }
    }
}
