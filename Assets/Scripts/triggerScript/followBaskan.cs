using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class followBaskan : MonoBehaviour
{
    public GameObject baskan;
    public GameObject target2;
    public GameObject beforeCrashcoll;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("car"))
        {
            baskan.GetComponent<Animator>().SetInteger("flash", 4);
            baskan.GetComponent<goLab>().enabled=false;
            baskan.GetComponent<NavMeshAgent>().SetDestination(target2.transform.position);
            beforeCrashcoll.SetActive(true);
            Destroy(gameObject);
        }
    }
}
