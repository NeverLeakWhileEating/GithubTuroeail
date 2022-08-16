using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle, // 待机
    Patrol, // 巡逻
    Trace, // 追击
    Back, // 返回
    Attack, // 攻击
    Death, // 死亡
}
public class FSM : MonoBehaviour
{
    // 参数
    // 巡逻速度
    public float patrolSpeed;
    // 巡逻半径
    public float patrolRadius;
    // 追击速度
    public float traceSpeed;
    // 追击半径 ， 锁敌人径
    public float traceRadius;
    // 返回速度
    public float backSpeed;
    // 攻击半径
    public float attackRadius;
    // 巡逻等待时间
    public float waitTime;
    // 计时器
    private float timer;

    // 拿到玩家的位置
    public Transform player;

    // 敌人当前的状态
    State state;
    // 动画状态机组件
    Animator actor;
    // 自动寻路组件
    NavMeshAgent nav;
    // ? 表示可空类型
    Vector3? originPos = null;

    // 敌人的初始位置：作为巡逻区域的中心点
    public Vector3 OriginPos
    {
        get {
            if (originPos == null)
            {
                originPos = transform.position;
            }
            // ??表示判断是否还为空 ， 如果还为空 给他一个  Vector3.zero ，只是为了应付编译器
            return originPos ??Vector3.zero;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        state = State.Idle;
        actor = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }
    public void Init()
    {

    }

    // Update is called once per frame
    void Update()  // Time.deltaTime 一帧的时间
    {
        // 检测敌人当前的状态是什么
        // 执行对应的状态函数
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Patrol:
                Patrol();
                break;
            case State.Trace:
                Trace();
                break;
            case State.Back:
                Back();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Death:
                Death();
                break;
            default:
                break;
        }
        // 设置动画
        actor.SetInteger("State", (int)state);

    }

    // 在巡逻范围内生成一个随机巡逻点
    private Vector3 CreatePos()
    {
        float x = Random.Range(-1f, 1f); // 
        float z = Random.Range(-1f, 1f); // 
        // 确定该点的方向
        Vector3 dir = new Vector3(x, 0, z).normalized; // 向量归一化
        // 确定最终的巡逻点
        Vector3 desPos = dir * patrolRadius + OriginPos;
        // 随机该线段上的一个点  ,达到二次随机 巡逻距离的效果
        float t = Random.Range(0f, 1f);
        desPos *= t;
        return desPos;

    }


    // 所有的状态函数都是在判定变为另一个状态
    private void Idle() // 巡逻 追击
    {
        // 切换到巡逻状态
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            // 执行计时器周期功能  , 修改状态
            state = State.Patrol;
            // 随机创建一个巡逻点
            nav.speed = patrolSpeed;
            nav.stoppingDistance = 0;
            nav.SetDestination(CreatePos());
           
            // 重置计时器
            timer = 0;

        } else // 切换到追击状态
        if(Vector3.Distance(player.position,transform.position)<= traceRadius)
        {
            state = State.Trace; // 设置状态
            nav.speed = traceSpeed; // 设置寻路速度
        }

    }

    private void Patrol() {
        // 切换到待机状态
        // remainingDistance 单次自动寻路的剩余路径长度
        if(nav.remainingDistance <= 0.5f)
        {
            state = State.Idle;
        }

        // 切换到追击状态
        else if (Vector3.Distance(player.position, transform.position) <= traceRadius)
        {
            state = State.Trace; // 设置状态
            nav.speed = traceSpeed; // 设置寻路速度
        }

    }
    private void Trace() {
        // 切换到攻击模式
        if (Vector3.Distance(player.position, transform.position) <= attackRadius)
        {
            state = State.Attack; // 设置状态

        }  //   如果与玩家的距离 大于等于 追击范围， 切换 到返回状态
        else if (Vector3.Distance(player.position, transform.position) > traceRadius)
        {
            state = State.Back; // 设置状态
            nav.speed = backSpeed;// 设置速度
            nav.stoppingDistance = 0;

        }// 敌人依然在追击玩家
        else
        {       // 让敌人保持持续锁敌
            // 自动寻路的停止距离不要超过攻击半径
            nav.stoppingDistance = 1;
            nav.SetDestination(player.position);  // 设置寻路终点，玩家位置

        }
    }

    private void Back() {
        if (nav.remainingDistance <= 0.5f) // 回到原始位置后 返回到待机状态
        {
            state = State.Idle; //设置状态
            // 重置计时器
            timer = 0;
        }
        else if (Vector3.Distance(player.position, transform.position) <= traceRadius) // 追击
        {
            state = State.Trace; // 设置状态
            nav.speed = traceSpeed; // 设置寻路速度
            
        }

    }

    private void Attack() {
        // 切换到追击
        if (Vector3.Distance(player.position, transform.position) > attackRadius)
        {
            state = State.Trace; // 设置状态
            nav.speed = traceSpeed; // 设置寻路速度
        }
    }

    private void Death() {

    }
}
