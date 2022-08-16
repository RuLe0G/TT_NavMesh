using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public BotData botData;

    
    private void Start()
    { 
        botData = GetComponent<BotData>();
        agent = GetComponent<NavMeshAgent>(); 
    }
    public void Init(float speed)
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    public void MoveToTarg()
    {
        StartCoroutine(Atach(target));
    }
    public bool isReached;

    private IEnumerator Atach(Transform target)
    {
        while(!CheckDestinationReached())
        {            
            agent.SetDestination(target.position);
            yield return null;
        }
        agent.SetDestination(this.transform.position);
        yield return null;
    }

    private bool CheckDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 1.5f)
        {
            return true;
        }
        return false;
    }

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

    public void SetTaget(Transform trg)
    {
        target = trg;
    }

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
            return hits[num2].transform;
        }
        return null;
    }
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
