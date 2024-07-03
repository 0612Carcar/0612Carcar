using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ConfigManager : SIngleton<ConfigManager>
{
    
    public void LoadAllJson()
    {
        LoadJson();
    }

    private void LoadJson()
    {
        try
        {
            
        }
        catch (Exception)
        {

            throw;
        }
    }
}


public class ShopData
{
    public string id;
    public string name;
    public string icon;
    public string inventoryType;
    public string equipType;
    public string sale;
    public string starLevel;
    public string quality;
    public string damage;
    public string hp;
    public string power;
    public string Des;
    public string ssr;
}