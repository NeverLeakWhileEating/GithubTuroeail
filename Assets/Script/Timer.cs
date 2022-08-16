using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading; // Thread 线程
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 计时器
    float timer;
    // 计时器周期，事件间隔
    float interval;
    int count;
    // Start is called before the first frame update
    void Start()
    {

        // 每隔3秒在控制台打印
        timer = 0;
        interval = 3;
        count = 1;
        // 延时调用函数
        // 1.延时调用的函数名
        // 2.延迟调用的时间
        //Invoke("Print",1.5f);
        // 协程函数（计时器的优化版本）
        // 进程 ： 在计算机中，表示一个正在执行的程序
        // 线程  : 进程中连续的单一控制流程，一个进程可以有多个线程，线程收进程控制的
        //，协程： 是一个轻量级的进程，由另一段进程开启，协程不受开启他的进程控制，一旦开始协程，不受主进程控制，监控
        // 开启协程 Coroutine
        // 协程函数的返回值必须为 IEnumerator
        //StartCoroutine("Print");
        //StopCoroutine("Print");
        // StartCoroutine("Print");
        // Print();
        //StartCoroutine(Print());
        //StopCoroutine(Print());

        //// 线程是一个对象 ，脚本没了 ，线程也就没了
        //Thread t1 = new Thread(Fun);
        //Thread t2 = new Thread(Fun1);
        //// 没有返回值 且没有参数的函数才能放进去,这样这个函数就变成了一个线程
        //t1.Start();
        //t2.Start();
        //t1.Abort();
        // // st1.ThreadState;
    }

    //void Fun() {
    //    while (true)
    //    {
    //        print("X");
    //    }
    //}

    //void Fun1()
    //{
    //    while (true)
    //    {
    //        print("Y");
    //    }
    //}

    //IEnumerator Print()
    //{
    //    // 每十秒出一波怪，每波怪出五个，每个间隔1
    //    while (true)
    //    {
    //        // yield 表示语法糖，让函数返回返回值但不退出函数
    //        for (int i = 0; i < 5; i++)
    //        {
    //            print($"出第{i + i}个怪");
    //            yield return new WaitForSeconds(1);
    //        }
    //        yield return new WaitForSeconds(10);
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        // 计时器自动增长
        //timer += Time.deltaTime;
        //if(timer >= interval)
        //{
        //    // 计时器周期满，执行功能
        //    Debug.Log(count);
        //    count++;
        //    timer = 0;
        //}
    }

   
}
