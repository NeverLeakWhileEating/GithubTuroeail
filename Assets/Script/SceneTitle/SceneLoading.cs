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
// 控制场景的跳转
public class SceneLoading : MonoBehaviour
{
    AsyncOperation ope;
    // 获取UI组件
    public Slider slider;
    public Text text;
    // 模拟一个进度条进度
    float targetProgress; // 目标进度
    void Start()
    {
        // 异步加载场景
        targetProgress = 0;
        StartCoroutine("LoadScene");
        
    }
    private IEnumerator LoadScene()
    {

        // 异步加载场景，获取该异步加载的数据
        ope = SceneManager.LoadSceneAsync("game");
        // 让场景不自动跳转
        ope.allowSceneActivation = false;
        // ope.progress: [0,1]
        while (ope.progress < 0.9f)
        {
            // 异步加载还在进行，模拟滑动条和文本缓慢增长 targetProgress
            while (targetProgress < ope.progress)
            {
                // 1. ++ 2.每帧自增dt 
                targetProgress += Time.deltaTime;
                // 模拟精度自增后 给文本和滑动条设置值
                // 滑动条
                slider.value = targetProgress;
                // 文本
                // text.text
                int value = (int)(targetProgress * 100);
                text.text = "加载中" + value + "%...";
                // 设置时间间隔: -帧
                yield return new WaitForEndOfFrame();
            }
        }
        // 模拟90%以上的进度情形
        targetProgress = 1;
        while (slider.value < targetProgress)
        {
            // 改变滑动条的值
            slider.value += Time.deltaTime;
            // 设置文本的
            int value = (int)(targetProgress * 100);
            text.text = "加载中" + value + "%...";

            // 设置时间间隔: -帧
            yield return new WaitForEndOfFrame();
        }
        text.text = "按下任意键继续。。。";

    }

    private void OnDestroy()
    {
        StopCoroutine("LoadScene");
    }

    void Update()
    {
        if (Input.anyKey && slider.value == 1)
        {
            ope.allowSceneActivation = true;
        }
    }
}
