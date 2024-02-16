using UnityEngine;
using UnityEngine.AI; // 引入导航组件的命名空间

public class MonsterAI : MonoBehaviour
{
    public Transform playerTransform; // 玩家的位置
    public float detectionRange = 10f; // 检测玩家的范围
    public float patrolRange = 5f; // 巡逻范围
    public float attackDistance = 2f; // 攻击距离
    public float patrolTime = 3f; // 每隔多少秒执行一次巡逻

    private Vector3 startPosition; // 开始位置
    private NavMeshAgent agent; // 导航代理
    private float patrolTimer; // 巡逻计时器

    void Start()
    {
        startPosition = transform.position; // 记录初始位置
        agent = GetComponent<NavMeshAgent>(); // 获取NavMeshAgent组件
        patrolTimer = patrolTime; // 初始化巡逻计时器
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position); // 计算到玩家的距离

        if (distanceToPlayer < detectionRange)
        {
            // 如果玩家进入检测范围内，则追踪玩家
            agent.SetDestination(playerTransform.position);

            if (distanceToPlayer <= attackDistance)
            {
                AttackPlayer(); // 如果进入攻击范围，则攻击玩家
            }
        }
        else
        {
            // 否则，执行巡逻行为
            Patrol();
        }
    }

    void Patrol()
    {
        patrolTimer -= Time.deltaTime;

        if (patrolTimer <= 0f)
        {
            Vector3 newPatrolPoint = Random.insideUnitSphere * patrolRange + startPosition; // 生成一个新的巡逻点
            newPatrolPoint.y = transform.position.y; // 保持y轴不变
            agent.SetDestination(newPatrolPoint); // 设置新的巡逻目标
            patrolTimer = patrolTime; // 重置计时器
        }
    }

    void AttackPlayer()
    {
        // 实现攻击逻辑
        Debug.Log("Attacking the player!");
    }
}
