using System.Collections;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Класс передвижения бота
/// </summary>
public class BotMovement : MonoBehaviour
{
    /// <summary>
    /// Объект/цель движения
    /// </summary>
    public Transform target;
    private NavMeshAgent agent;
    /// <summary>
    /// Объект характеристик бота
    /// </summary>
    public BotData botData;
    /// <summary>
    /// Определяет достиг ли бот цели
    /// </summary>
    public bool isReached = false;

    private void Start()
    { 
        botData = GetComponent<BotData>();
        agent = GetComponent<NavMeshAgent>(); 
    }
    /// <summary>
    /// Инициализация NavMeshAgent, изменение скорости
    /// </summary>
    /// <param name="speed">Скорость объекта</param>
    public void Init(float speed)
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }
    /// <summary>
    /// Функция запускает корутину движения.
    /// </summary>
    public void MoveToTarg()
    {
        StartCoroutine(Atach(target));
    }

    /// <summary>
    /// Движение в сторону таргета, до приближения
    /// </summary>
    /// <param name="trg">Метка/цель</param>
    /// <returns></returns>
    private IEnumerator Atach(Transform trg)
    {
        if (trg != null)
        {

        while(!CheckDestinationReached())
        {
            if (trg != null)
            {                
            agent.SetDestination(trg.position); yield return null;
            }
            yield return null;
        }
        agent.SetDestination(this.transform.position);
        isReached = true;
        yield return null;

        }
        yield return null;
    }

    private bool CheckDestinationReached()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < 1.5f)
            {
                return true;
            }
            return false;
        }
        else
            return false;
    }
    /// <summary>
    /// Функция высчитывает длину пути до объекта
    /// </summary>
    /// <returns></returns>
    public float CalculatePath()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target.position, path);

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = target.position;
        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }
        float pathLength = 0;

        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
        return pathLength;
    }
    /// <summary>
    /// Установить метку на входной объект
    /// </summary>
    /// <param name="trg"></param>
    public void SetTaget(Transform trg)
    {
        target = trg;
    }
    /// <summary>
    /// Получить объект на котором метка
    /// </summary>
    /// <returns></returns>
    public Transform GetTarget()
    {
        return target;
    }
    /// <summary>
    /// Функция поиска ближайшего объекта
    /// </summary>
    /// <returns></returns>
    public Transform MarkClosedTarget()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, 35f, LayerMask.GetMask("isObj"));
        if (hits.Length > 0)
        {

            float num = float.MaxValue;
            int num2 = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.root != transform)
                {
                    Transform num3 = hits[i].transform;
                    target = num3;
                    var num4 = CalculatePath();
                    if (num4 < num)
                    {
                        num2 = i;
                        num = num4;
                    }
                }
            }
            if (hits[num2].transform.root != transform)
            {
                return hits[num2].transform;
            }
            else
                return null;
        }
        return null;
    }
    /// <summary>
    /// Функция поиска случайного объекта
    /// </summary>
    /// <returns></returns>
    public Transform MarkRandomTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 35f, LayerMask.GetMask("isObj"));
        if (hits.Length > 0)
        {
            int num = Random.Range(0, hits.Length);

            return hits[num].transform;

        }
           return null; 
        }
        
}
