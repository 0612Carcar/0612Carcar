using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void Init() { }
    public virtual void Show() { gameObject.SetActive(true); }
    public virtual void Hold() { gameObject.SetActive(false); }

}
