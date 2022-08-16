using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Login : MonoBehaviour
{
    // 拿到输入框组件
    public InputField userName;
    public InputField passWord;

    void Start()
    {
        // .Trim() 去除空格 头尾空格去掉
        //Regex regex = new Regex("0?(13|14|15|17|18|19)[0-9]{9}");
        //regex.IsMatch("13722"); // 匹配成功
    }

    void Update()
    {
        
    }

    public void OnBtnRegister()
    {
        // 获取当前输入框内的用户名和密码
        string username = userName.text;
        string pwd = passWord.text;
        if (AccountModule.Instance.Register(username, pwd))
        {
            print("注册成功");
            // 跳转到加载场景
           // SceneManager.LoadScene("Loading");
             
        }
        else
        {
            print("注册失败");
        }
    }

    public void OnBtnLogin()
    { // 获取当前输入框内的用户名和密码
        string username = userName.text;
        string pwd = passWord.text;
        if (AccountModule.Instance.Login(username, pwd))
        {
            print("登录成功");
        }
        else
        {
            print("登录失败");
        }

    }

    //private void OnDestroy()
    //{
       
    //}

}
