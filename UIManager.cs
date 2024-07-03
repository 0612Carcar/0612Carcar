using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelType
{
    Noit,
    Huchi,
    Main
}

public enum PanelName
{
    
}

public class UIManager : SIngleton<UIManager>
{
    //缓存
    Dictionary<PanelName, UIBase> DicUI = new Dictionary<PanelName, UIBase>();

    public Transform ploat;

    public UIManager()
    {
        ploat = GameObject.Find("Canvas").transform;
    }
    //打開UI
    public void OpenUI(PanelName name)
    {
        UIBase ui = LoadUI(name);
        ui.Show();
    }
    //加载UI
    private UIBase LoadUI(PanelName name)
    {
        UIBase TypeUI;
        if (DicUI.TryGetValue(name,out TypeUI))
        {
            Debug.Log("第N次打开");
        }else
        {
            GameObject obj = Resources.Load<GameObject>("UIPanel/" + name.ToString());
            if (obj == null)
            {
                Debug.Log("加载失败 请检查");
            }else
            {
                GameObject g = GameObject.Instantiate(obj, ploat);
                TypeUI = g.GetComponent<UIBase>();
                if (TypeUI == null)
                {
                    Debug.Log("没有继承");
                }else
                {
                    Debug.Log("第一次打开");
                    DicUI.Add(name, TypeUI);
                    DicUI[name].Init();
                }
            }
        }
        return TypeUI;
    }
    //关闭UI
    public void CloseUI(PanelName name)
    {
        if (DicUI.ContainsKey(name))
        {
            DicUI[name].Hold();
        }
    }
}
