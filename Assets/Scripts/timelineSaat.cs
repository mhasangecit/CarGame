using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class timelineSaat : MonoBehaviour
{
    public PlayableDirector tlSaat;
    public GameObject missionObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tlSaat.Play();

            missionObject.GetComponent<mission>().newMission();

            Destroy(gameObject);
        }
    }
}
