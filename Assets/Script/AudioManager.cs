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

public class AudioManager : MonoBehaviour
{
    // 模拟挂载脚本的单例
    public static AudioManager Instance = null;

    // 获取组件
    AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        AudioManager.Instance.PlayMusic("zhibuguoshi");
        // 音效的播放
        // 在指定地点播放音效
        // 1.要播放的音频文件 2.要播放音频的位置
        // AudioSource.PlayClipAtPoint();
    }

    void Update()
    {
    }

    /// <summary>
    /// 播放背景音乐，不负责播放短音效
    /// </summary>
    /// <param name="path">要播放的音乐文件的名字</param>
    /// <param name="volume">音量大小，默认为一</param>
    /// <param name="loop">是否循环播放，默认循环</param>
    public void PlayMusic(string path, float volume = 1, bool loop = true)
    {
        // 加载音频文件，更换要播放的音频
        audioSource.clip = ResourcesManager.Instance.Load<AudioClip>(path);
        // 设置音量大小
        audioSource.volume = volume;
        // 设置是否循环
        audioSource.loop = loop;
        audioSource.Play();
    }
}
