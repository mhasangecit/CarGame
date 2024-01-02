using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelineManage : MonoBehaviour
{
    public GameObject baskanSaatli;
    public PlayableDirector[] timelines;
    public float[] waitTmlnSecond;
    public static int tmlnCount=-1;

    public GameObject misObject;

    public GameObject saat;

    void Start()
    {
    }

    public void timelinePlay()
    {
        tmlnCount++;
        StartCoroutine(timelineStart(timelines[tmlnCount], waitTmlnSecond[tmlnCount]));
    }

    IEnumerator timelineStart(PlayableDirector timeline, float waitSec)
    {
        yield return new WaitForSeconds(waitSec);
        baskanSaatli.SetActive(true);
        timeline.Play();

        if (timeline.name == "timeline1") //baþkan saatini al yazýsý
        {
            print("timeline karsýlastýrma");
            StartCoroutine(saatiAl(18.80f));
        }
    }

    public void tmln1SaatAktif()
    {
        saat.SetActive(true);
    }

    IEnumerator saatiAl(float waitSec)
    {
        yield return new WaitForSeconds(waitSec);
        misObject.GetComponent<mission>().newMission();
    }
}
