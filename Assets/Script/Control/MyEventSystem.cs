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

// public delegate void Fun(object obj);
// Action<object>
// static Dictionary<EventType, Fun> eventDict = new Dictionary<EventType, Fun>();


public class MyEventSystem : SingleBase<MyEventSystem>
{

    // 数据部分
    // 用于储存事件类型 和与之对应的委托
    static Dictionary<EventType, Action<object>> eventDict = new Dictionary<EventType, Action<object>>();
    // API部分
    /// <summary>
    /// 向某一指定事件类型中添加多播委托
    /// </summary>
    /// <param name="type">加入的事件类型</param>
    /// <param name="fun">添加到多播委托的函数</param>
    public void AddListener(EventType type, Action<object> fun)
    {
        if (eventDict.ContainsKey(type))
        {
            // 如果有，则添加至多播委托
            eventDict[type] += fun;
        }
        else
        {
            // 如果没有，先创建该事件类型的对应关系
            eventDict.Add(type, fun);
        }
    }

    /// <summary>
    /// 向某一指定事件类型中删除某个委托
    /// </summary>
    /// <param name="type">指定的事件类型</param>
    /// <param name="fun">要删除的函数</param>
    public void RemoveListener(EventType type, Action<object> fun)
    {
        if (eventDict.ContainsKey(type))
        {
            eventDict[type] -= fun;
        }
    }

    /// <summary>
    /// 执行某一事件类型的多播委托
    /// </summary>
    /// <param name="type">指定的事件类型</param>
    /// <param name="obj">执行委托是传入的参数</param>
    public void Dispatch(EventType type,object obj = null)
    {
        if (eventDict.ContainsKey(type))
        {
            // 执行对应的多播委托
            eventDict[type](obj);
        }
    }

    /// <summary>
    /// 在跳转场景时情况所存储的数据
    /// </summary>
    public void Clear()
    {
        eventDict.Clear();
    }

}
