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
    //����
    Dictionary<PanelName, UIBase> DicUI = new Dictionary<PanelName, UIBase>();

    public Transform ploat;

    public UIManager()
    {
        ploat = GameObject.Find("Canvas").transform;
    }
    //���_UI
    public void OpenUI(PanelName name)
    {
        UIBase ui = LoadUI(name);
        ui.Show();
    }
    //����UI
    private UIBase LoadUI(PanelName name)
    {
        UIBase TypeUI;
        if (DicUI.TryGetValue(name,out TypeUI))
        {
            Debug.Log("��N�δ�");
        }else
        {
            GameObject obj = Resources.Load<GameObject>("UIPanel/" + name.ToString());
            if (obj == null)
            {
                Debug.Log("����ʧ�� ����");
            }else
            {
                GameObject g = GameObject.Instantiate(obj, ploat);
                TypeUI = g.GetComponent<UIBase>();
                if (TypeUI == null)
                {
                    Debug.Log("û�м̳�");
                }else
                {
                    Debug.Log("��һ�δ�");
                    DicUI.Add(name, TypeUI);
                    DicUI[name].Init();
                }
            }
        }
        return TypeUI;
    }
    //�ر�UI
    public void CloseUI(PanelName name)
    {
        if (DicUI.ContainsKey(name))
        {
            DicUI[name].Hold();
        }
    }
}
