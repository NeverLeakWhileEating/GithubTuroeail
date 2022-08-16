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

public class SwitchImg : MonoBehaviour
{
    // 拿到所有Toggle组件  0佐助，1鸣人，2小樱
    public Toggle[] toggles;
    // 拿到要切换的头像图
    public Sprite[] portraitImgs;
    // 拿到要切换的名字图
    public Sprite[] nameImgs;

    // 获取头像和名字的Image组件
    public Image portrait;
    public Image img;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnValueChanged()
    {
        int index = -1; // 遍历toggles,检测其中那个isOn属性为true
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                index = i;
                break;
            }
        }
        if (index == -1) return;
        // 在修改图片前调整Image的大小
        // 获取原图片的长宽
        float width = nameImgs[index].rect.width;
        float height = nameImgs[index].rect.height;
        // 将获取到的宽到设置给image组件
        // 设置宽
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        // 设置高
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);

        // 去修改头像和名字的图片
        portrait.sprite = portraitImgs[index];
        img.sprite = nameImgs[index];
    }

}
