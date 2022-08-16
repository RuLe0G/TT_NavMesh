using System.Collections;
using System.Collections.Generic;
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
        agent.speed = speed;
    }

    public void MoveToTarg()
    {
        target = GameObject.FindGameObjectWithTag("temp_targ").gameObject.GetComponent<Transform>();
        StartCoroutine(Atach(target.position));
    }

    private IEnumerator Atach(Vector3 target)
    {
        Vector3 targ = (target - base.transform.position) * 0.92f + base.transform.position;

        agent.SetDestination(targ);

        yield return null;
    }
}
