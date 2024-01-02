using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class mission : MonoBehaviour
{
    public GameObject newMiss;
    public TextMeshProUGUI missionText;
    public string[] missionList;
    public int i = 0; //yaz?numaralar?

    private void Start()
    {
    }

    public void newMission()
    {
        bekle(1.5f);
        GetComponent<Animator>().SetTrigger("newText");
        newMiss.GetComponent<Animator>().SetTrigger("newText");
        GetComponent<AudioSource>().Play();
        i++;
        if (i < missionList.Length)
            missionText.text = missionList[i];
    }

    public void newMissionWithParameter(string prmtr)
    {
        bekle(3f);
        GetComponent<AudioSource>().Play();
        missionText.text = prmtr;
    }

    IEnumerator bekle(float x)
    {
        yield return new WaitForSeconds(x);
    }
}
