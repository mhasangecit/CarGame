using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class keyInfo : MonoBehaviour
{
    public GameObject blackPanel;
    public GameObject imageBox;
    public TextMeshProUGUI infoText;
    string[] info = new string[2];
    public GameObject missionObject;
    public GameObject timelineManagerObject;
    public GameObject carScripted;
    public bool inCar=false;
    bool ePressed = false;
    bool carColl = false;
    bool fade = false;

    public int hlioCount = 0;
    public GameObject mihom;

    public GameObject escMenu;
    bool escState = false;

    private void Start()
    {
        info[0] = "Konuş";
        info[1] = "Bin/İn";

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !ePressed && carColl)
        {
            inCar = !inCar;
            ePressed = true; 
            if (inCar)
            {
                carScripted.GetComponent<rideCar>().ride();
                imageBox.SetActive(false);
                infoText.text = "";
            }
            else
            {
                carScripted.GetComponent<rideCar>().unRide();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            EscMenu();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("speaker"))
        {
            imageBox.SetActive(true);
            infoText.text = info[0];
        } 
        else if (other.CompareTag("car"))
        {
            imageBox.SetActive(true);
            infoText.text = info[1];
            carColl = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            imageBox.SetActive(false);

            if (other.name == "sitSpeakCol1")
            {
                mihom.GetComponent<npcDialog>().speak = true;
            }
            else if (!other.CompareTag("car"))
            {
                Transform obje = FindMainObject(other.gameObject.transform);
                obje.GetComponent<npcDialog>().speak = true;
                if (!other.name.StartsWith("sit"))
                    obje.LookAt(transform); 

                if (obje.name == "hlio" && hlioCount == 0)
                {
                    hlioCount++;
                    Debug.Log("hlioCount:" + hlioCount);
                    timelineManagerObject.GetComponent<timelineManage>().timelinePlay();
                }
            }
            else
            {
                ePressed = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        imageBox.SetActive(false);
        infoText.text = "";
        if(other.CompareTag("car")) carColl = false;
    }

    public Transform FindMainObject(Transform obje)
    {
        if (obje.parent != null)
            return FindMainObject(obje.parent);
        else
            return obje;
    }

    public void blackPanelFade()
    {
        fade = !fade;
        blackPanel.GetComponent<Animator>().SetBool("fade", fade);
        blackPanel.SetActive(false);
    }



    void EscMenu()
    {
        escState = !escState;

        if (escState)
        {
            Time.timeScale = 0f;
            escMenu.GetComponent<Animator>().SetTrigger("esc");
            escMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioListener.pause = true;
        }
        else
        {
            escMenu.SetActive(false);
            Time.timeScale = 1f;
            escMenu.GetComponent<Animator>().SetTrigger("esc");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AudioListener.pause = false;
        }
    }
}
