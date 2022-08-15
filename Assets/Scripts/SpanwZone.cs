using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwZone : MonoBehaviour
{
    [SerializeField]
    private GameObject bots;

    private int count;
    public int range;
    
    private void Update()
    {   
        if (count < range)
        {
            SpawnBots();
            count++;
        }        
    }

    private void SpawnBots()
    {
        float modX = transform.localScale.x/2;
        float modZ = transform.localScale.z/2;

        float numX = Random.Range(transform.position.x + modX, transform.position.x - modX);
        float numZ = Random.Range(transform.position.z + modZ, transform.position.z - modZ);

        Instantiate(bots, new Vector3(numX, 1, numZ), Quaternion.identity);
    }
}
