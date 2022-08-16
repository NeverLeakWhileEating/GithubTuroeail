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

public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        // 防止跳转场景销毁
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    private void OnDestroy()
    {
        // 登录注册信息保存
        AccountModule.Instance.SaveXml();
    }
}
