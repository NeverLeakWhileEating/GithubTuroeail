using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // 获取状态机组件
    Animator actor;
    // 获取角色控制器组件
    CharacterController controller;
   
    // 玩家移动所需的参数
    // 移动速度
    public float moveSpeed;
    // 跳跃速度
    public float jusmpSpeed;
    // 鼠标灵敏度
    public float mouseSensitivity;
    // 代表玩家的移动量
    Vector3 playerMove;
    // 模拟重力
    private const float gravity = 9.8f;

    void Start()
    {
      
        actor = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        // 隐藏和锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // 优先检测玩家是否在地面 
        if (controller.isGrounded)
        {
            // 横向的和纵向的轴输入
            // [-1,1] 
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxis("Vertical");
            //if (hor != 0 || ver != 0)
            //{   // 判定玩家正在移动
            //    actor.SetBool("Run", true);
            //}
            //else
            //{
            //    // 玩家没有移动
            //    actor.SetBool("Run", false);
            //}
            actor.SetFloat("Hor", hor);
            actor.SetFloat("Ver", ver);

            // 将xy平面的移动量整合进plyaerMove中
            // new Vector3(hor, 0, ver)  
            playerMove =
                // transform.forward(0,0,1)
                // transflorm.right(1,0,0) 基于玩家的方向
                (transform.forward * ver + transform.right * hor) *moveSpeed;
            // 跳跃
            // Input.GetAxis("Jump") : 0或1
            if(Input.GetAxis("Jump") == 1)
            {
                actor.SetTrigger("Jump");
                playerMove.y += jusmpSpeed;
            }
        }
        // 把重力加进去  
        playerMove.y -= gravity * Time.deltaTime;
        // 根据移动量移动
        controller.Move(playerMove * Time.deltaTime);

        // 让角色跟随鼠标移动旋转
        // MouseX轴输入
        float mouseX = Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(0,mouseX,0) * Time.deltaTime * mouseSensitivity;
        // 按键攻击
        if (Input.GetMouseButtonDown(0))
        {
            actor.SetTrigger("Attack");
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }

}
