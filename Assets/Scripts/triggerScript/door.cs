using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject baskan;
    public GameObject mission;
    public GameObject goFlashColl;
    public GameObject[] doorsColl;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && mission.GetComponent<mission>().i==2)
        {
            baskan.SetActive(true);
            goFlashColl.SetActive(true);
            baskan.GetComponent<Animator>().SetTrigger("go");
            Destroy(doorsColl[0]);
            Destroy(doorsColl[1]);
        }
    }
}
