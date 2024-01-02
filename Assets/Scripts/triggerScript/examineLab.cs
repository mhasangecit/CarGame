using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class examineLab : MonoBehaviour
{
    public GameObject image;
    public GameObject car;
    public PlayableDirector labScene;
    public GameObject mission;
    public GameObject flash;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            labScene.Play();
            Destroy(gameObject);
        }

        if (collision.CompareTag("baskan"))
        {
            Destroy(collision.gameObject);
            flash.SetActive(true);
            mission.GetComponent<mission>().newMission();
        }
    }
}
