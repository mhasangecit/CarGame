using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class goLab : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);       
    }
}
