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

public enum EventType 
{
   ChangeHP_V,// 显示层的血量改变
   ChangeHp_M, // 数据层血量改变
}
