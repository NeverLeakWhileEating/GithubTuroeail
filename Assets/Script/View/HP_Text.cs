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

public class HP_Text : MonoBehaviour
{
    // 获取组件
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        // 将自身改变血量显示的函数添加到观察者的事件中
        // HP_Observer.AddFun(ChangeHp);
        MyEventSystem.Instance.AddListener(EventType.ChangeHP_V, ChangeHp);

    }

    private void Start()
    {
        PlayerAttributeModule.Instance.InitData();
    }

    void Update()
    {

    }

    void ChangeHp(object obj)
    {
        Hp hp = (Hp)obj;
        text.text = hp.hp + "/" + hp.hpMax;
    }

}
