using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    // 苦无  拿到武器的碰撞组件
    public Collider kunai;
    // Start is called before the first frame update
    void Start()
    {
        CloseCollider();// 保证一开始是关闭的
    }

    public void OpenCollider()
    {
         kunai.enabled = true;
    }

    public void CloseCollider()
    // 底层是反射获取的 所以 能获取到类中所有的东西 也包括 pritate   
    // 但是为了其他外部也能调用 所有还是加 public
    {
        kunai.enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {

    }
}
