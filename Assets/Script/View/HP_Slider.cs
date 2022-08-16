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

public class HP_Slider : MonoBehaviour
{
    // 获取组件
    Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
        // 将自身改变血量显示的函数添加到观察者的事件中
        // HP_Observer.AddFun(ChangeHp);
        MyEventSystem.Instance.AddListener(EventType.ChangeHP_V, ChangeHp);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 玩家扣血
            MyEventSystem.Instance.Dispatch(EventType.ChangeHp_M, 10);
        }
    }
    void ChangeHp(object obj)
    {
        Hp hp = (Hp)obj;
        // 将滑动条的最大值设为声明值最大值
        slider.maxValue = hp.hpMax;
        // 让当前值匹配当前生命值
        slider.value = hp.hp;
    }

}
