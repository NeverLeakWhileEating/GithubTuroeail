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
/*
 * 1. 在加载资源时先查看是否保存
 * - 没有保存时使用Load首次加载资源
 * - 保存过的资源则直接从字典里拿来使用
 * 2. 匹配Resources自带的两个Load - 两个仓库资源
 */
public class ResourcesManager
{
    #region 单例模式
    private static ResourcesManager instance = null;
    private ResourcesManager() { }
    public static ResourcesManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResourcesManager();
            }
            return instance;
        }
    }
    #endregion  

    // 两个仓库存放资源
    // Resources.Load();加载预制体  

    Dictionary<string, GameObject> resDict = new Dictionary<string, GameObject>();
    // Load<>() 除预制体以外的其他资源
    // 哈希表HashTable : 字典的非泛型版本
    Hashtable resTable = new Hashtable();

    // API部分
    /// <summary>
    /// 加载预制体资源文件
    /// </summary>
    /// <param name="path">预制体的路径名</param>
    /// <returns>加载到的预制体</returns>
    public GameObject Load(string path)
    {
        // 检查容器中是否已有该资源
        if (resDict.ContainsKey(path))
        {
            return resDict[path];
        }
        else
        {
            // 没有保存则加载资源
            GameObject obj = Resources.Load(path) as GameObject;
            // 将加载好的资源保存到字典中
            resDict.Add(path, obj);
            return obj;
        }
    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {
        // 检查资源是否存在
        if (resTable.ContainsKey(path))
        {
            return resTable[path] as T;
        }
        else
        {
            // 通过带泛型的Load加载资源
            T obj = Resources.Load<T>(path);
            resTable.Add(path, obj);
            return obj;
        }
    }



}
