using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MsgID
{
    
}

public class MsgManager<T> :SIngleton<MsgManager<T>>
{
    Dictionary<MsgID, Action<T>> DicMsg = new Dictionary<MsgID, Action<T>>();

    public void OnAddListen(MsgID msg,Action<T> action)
    {
        if (DicMsg.ContainsKey(msg))
        {
            DicMsg[msg] += action;
        }else
        {
            DicMsg.Add(msg, action);
        }
    }

    public void OnRemoveListen(MsgID msg)
    {
        DicMsg.Remove(msg);
    }

    public void OnDisPath(MsgID msg, T t)
    {
        if (DicMsg.ContainsKey(msg))
        {
            DicMsg[msg](t);
        }
    }
}
