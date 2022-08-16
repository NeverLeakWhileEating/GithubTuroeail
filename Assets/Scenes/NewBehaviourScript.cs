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
[RequireComponent(typeof(Rigidbody))]
public class NewBehaviourScript : MonoBehaviour
{
    [Space(10)]
    Rigidbody rb;

    [Tooltip("这是一个数字")] [Range(-100, 100)] public int speed = 0;
    [Header("Health")]
    public int health = 0;
    [TextArea]
    public string MyTextArea;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // print(MyTextArea);
    }
}
