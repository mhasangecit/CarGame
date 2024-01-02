using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endWrite : MonoBehaviour
{
    public string[] yazilar;
    public TextMeshProUGUI endText;
    int i = 0;

    public GameObject flash;
    public GameObject mission;
    public GameObject Player;
    public Transform afterTl;
    playerController player;

    void Start()
    {
        player = Player.GetComponent<playerController>();
    }

    void Update()
    {
        
    }

    public void nextText()
    {
        i++;
        endText.text = yazilar[i];
    }

    public void finishGame()
    {
        Destroy(flash);
        mission.GetComponent<mission>().newMissionWithParameter("Yeni özellik açıldı. Shift Tuşu ile Flash koşusu yapabilirsin.");
        player.flashButton = KeyCode.LeftShift;
        player.sprintButton = KeyCode.Tab;
        player.transform.position = afterTl.position;
    }
}
