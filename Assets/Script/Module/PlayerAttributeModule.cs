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
public struct Hp
{
    public int hp;
    public int hpMax;
    public Hp(int hp, int hpMax)
    {
        this.hp = hp;
        this.hpMax = hpMax;
    }
}

public class PlayerAttributeModule : SingleBase<PlayerAttributeModule>
{
    // 因为需要在其他类中SingleBase中调用 构造函数
    // 所有继承SingleBase的子类构造函数必须是public的
    Hp hp;
    public void InitData()
    {
        hp = new Hp(100, 150);
        MyEventSystem.Instance.Dispatch(EventType.ChangeHP_V, hp);
        // 将玩家数据层改变血量的函数加到事件系统中
        MyEventSystem.Instance.AddListener(EventType.ChangeHp_M, GetHurt);
    }

    // 玩家生命值数据改变
    void GetHurt(object obj)
    {
        // 即那个时间系统传递的参数转换为伤害值
        int damage = (int)obj;
        hp.hp -= damage;
        MyEventSystem.Instance.Dispatch(EventType.ChangeHP_V,hp); // 改变 数据层的HP后 改变显示层的hp
    }


}
