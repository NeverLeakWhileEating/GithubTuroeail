using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SingleBase <T>
    where T : SingleBase<T>, // 表示T必须继承与SingleBase
    new()// 表示子类必须有一个无参构造函数
{
    private static T instance = null;
    protected SingleBase() {

    }
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
