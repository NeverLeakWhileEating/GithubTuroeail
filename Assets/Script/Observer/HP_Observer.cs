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

public class HP_Observer : MonoBehaviour
{

    // 玩家的生命值和最大生命值
    int hpMax;
    int hp;

    // 数据部分
   public delegate void Fun(int hp, int hpMax);
    // 用事件限制委托
    static event Fun changeHp;

  
    void Start()
    {
        PlayerAttributeModule player = new PlayerAttributeModule();
        
        hpMax = 100;
        hp = hpMax;
        // 初始化赋值
        changeHp(hp, hpMax);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hp -= 10;
            changeHp(hp, hpMax);
        }
    }

    public static void AddFun(Fun fun) {
        if(changeHp == null)
        {
            changeHp = fun;
        }
        else
        {
            changeHp += fun;
        }
    }
}
