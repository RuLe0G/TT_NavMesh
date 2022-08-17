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

    public bool isReached = false;

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
    public Transform GetTarget()
    {
        return target;
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
            if (hits[num2].transform.root != transform)
            {
                return hits[num2].transform;
            }
            else
                return null;
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
