using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class beforeCrash : MonoBehaviour
{
    public Transform target3;
    public GameObject crashTlColl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("baskan"))
        {
            other.GetComponent<Animator>().SetInteger("flash", 5);
            other.GetComponent<NavMeshAgent>().SetDestination(target3.position);
            crashTlColl.SetActive(true);
            Destroy(gameObject);
        }
    }
}
