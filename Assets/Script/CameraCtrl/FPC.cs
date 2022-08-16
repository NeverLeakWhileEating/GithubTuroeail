using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{
   
    // 拿到摄像机组件
    Camera cam;
    // 记录x的旋转值
    float rotationX;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // 鼠标上下移动控制摄像机抬头低头
        float MouseY = Input.GetAxis("Mouse Y");
        // [-70, 70] 低头抬头的 角度限制
        rotationX -= MouseY;
        // 将rotationX 限定在[-70, 70] 范围了
        // Mathf.Clamp(被限定的值，限定的下限值，限定的上限值)
        rotationX = Mathf.Clamp(rotationX, -65, 65);
        // 将旋转值应用到摄像机旋转上
        transform.eulerAngles = new Vector3(rotationX, transform.eulerAngles.y,transform.eulerAngles.z);


        // 鼠标滚轮控制角色视野范围大小
        float MouseSW = Input.GetAxis("Mouse ScrollWheel");
        if(MouseSW < 0 && cam.fieldOfView <= 100)
        {
            cam.fieldOfView += 2;
        }
        if (MouseSW > 0 && cam.fieldOfView >= 40)
        {
            cam.fieldOfView -= 2;
        }

    }
}
