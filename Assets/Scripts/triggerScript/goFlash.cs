using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goFlash : MonoBehaviour
{
    public GameObject baskan;
    public GameObject particle;
    public GameObject mission;
    public GameObject followColl;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            baskan.GetComponent<Animator>().SetInteger("flash",3);
            particle.SetActive(true);
            Destroy(gameObject);
            StartCoroutine(useCar());
            mission.GetComponent<mission>().newMission();
            followColl.SetActive(true);
        }
    }

    IEnumerator useCar()
    {
        yield return new WaitForSeconds(2.5f);
    }
}
