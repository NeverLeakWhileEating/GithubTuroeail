using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPC : MonoBehaviour
{
    public Transform player; // 获取玩家位置
    // 位置偏移量
    Vector3 offset;
    // 摄像机上抬的倍率
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        // 让摄像机看向玩家
        transform.LookAt(player.position + Vector3.up * rate);
    }




}
