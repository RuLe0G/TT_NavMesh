using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public BotData botData;

    ///
    public bool TempBool; 
    ///
    
    private void Start()
    { 
        botData = GetComponent<BotData>();
        agent = GetComponent<NavMeshAgent>();
        ///        
        target = GameObject.FindGameObjectWithTag("temp_targ").gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (TempBool)
        {
            StartCoroutine(Atach(target.position));
            TempBool = false;
        }
    }

    private IEnumerator Atach(Vector3 target)
    {
        Vector3 targ = (target - base.transform.position) * 0.92f + base.transform.position;

        agent.SetDestination(targ);

        yield return null;
    }
}
