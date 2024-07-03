using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : SIngleton<ModelManager>
{
    //缓存
    Dictionary<Type, ModelBase> DicModel = new Dictionary<Type, ModelBase>();

    public void LoadAllModel()
    {
        
        
    }

    void LoadModel(ModelBase model)
    {
        if (!DicModel.ContainsKey(model.GetType()))
        {
            DicModel.Add(model.GetType(), model);
            model.Init();
        }
    }
    //对外获取方法
    public T GetModel<T>() where T : ModelBase
    {
        if (DicModel.ContainsKey(typeof(T)))
        {
            return DicModel[typeof(T)] as T;
        }else
        {
            Debug.Log("没有注册数据类型" + typeof(T));
            return null;
        }
    }
}
