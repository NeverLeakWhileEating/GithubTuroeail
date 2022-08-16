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

public class AccountModule
{
    #region 单例模式
    private static AccountModule instance = null;
    private AccountModule()
    {
        // 读取xml文件的完整路径
        xmlPath = Application.dataPath + "/" + dirPath + "/" + fileName;
        LoadXml(); // 这个函数放入构造里面保证只会调用一次
    }
    public static AccountModule Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AccountModule();
            }
            return instance;
        }
    }
    #endregion

    // 存放xml文件的文件夹名
    string dirPath = "Configs";
    // 读取的xml文件名
    string fileName = "Account.xml";
    // 用于拼接读取xml文件的路径
    string xmlPath = "";

    // 数据部分：用户名 - 密码
    // 用于存储原本xml文件的用户名密码
    Dictionary<string, string> accountDict = new Dictionary<string, string>();
    // 用于存储新注册的用户名和密码
    Dictionary<string, string> newDict = new Dictionary<string, string>();
    #region API部分
    /// <summary>
    /// 在游戏开始时读取一次xml文件
    /// </summary>
    private void LoadXml()
    {
        // 新建xml文件
        XmlDocument xmlDoc = new XmlDocument();
        // 检测 xml文件是否存在
        if (!File.Exists(xmlPath))
        {
            // 添加根节点
            XmlNode root = xmlDoc.CreateElement("root");
            xmlDoc.AppendChild(root);
            // 保存新建xml文件
            xmlDoc.Save(xmlPath);
        }
        else
        {
            // 读取xml数据存到字典中
            xmlDoc.Load(xmlPath);
            XmlNode root = xmlDoc.SelectSingleNode("root");
            foreach (XmlElement element in root)
            {
                string username = element.GetAttribute("username");
                string pwd = element.GetAttribute("pwd");
                // 将xml中数据放到字典中
                accountDict.Add(username, pwd);
            }
        }
    }
    /// <summary>
    /// 登录函数
    /// </summary>
    /// <param name="username">登录使用的用户名</param>
    /// <param name="pwd">登录使用的密码</param>
    /// <returns>是否登陆成功</returns>
    public bool Login(string username, string pwd)
    {
        // 检查用户名是否存在
        if (accountDict.ContainsKey(username))
        {
            return accountDict[username] == pwd;
        }
        if (newDict.ContainsKey(username))
        {
            return newDict[username] == pwd;

        }
        return false;
    }

    /// <summary>
    /// 注册函数
    /// </summary>
    /// <param name="username">注册使用的用户名</param>
    /// <param name="pwd">注册使用的密码</param>
    /// <returns>是否注册成功</returns>
    public bool Register(string username, string pwd)
    {
        if (accountDict.ContainsKey(username) || newDict.ContainsKey(username))
        {
            return false;
        }
        newDict.Add(username, pwd);
        return true;
    }

    /// <summary>
    /// 保存xml数据，将新注册的用户信息写入
    /// </summary>
    public void SaveXml()
    {
         // 当存放新注册的字典中存在新数据时才写入
        if (newDict.Count != 0)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode root = xmlDoc.SelectSingleNode("root");
            // 遍历新注册的用户信息 转成 xmlEnemnt 加入到根节点下
            foreach (var item in newDict)
            {
                // 新建一条数据
                XmlElement element = xmlDoc.CreateElement("Account");
                // 添加用户名和密码
                element.SetAttribute("username", item.Key);
                element.SetAttribute("pwd", item.Value);
                root.AppendChild(element);
            }
            xmlDoc.Save(xmlPath);
        }
    }
    #endregion



}

