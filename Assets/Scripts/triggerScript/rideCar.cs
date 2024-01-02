using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using Cinemachine;

public class rideCar : MonoBehaviour
{
    public GameObject player;
    public Transform playerCamRoot;
    public GameObject driver;
    public GameObject car;
    public Transform carCamRoot;
    public bool plyFollowCar;
    public CinemachineFreeLook cmCam;
    public float inX, inY, inZ;
    public bool rideState = false;

    public void ride()
    {
        rideState = true;
        activeDrive();
    }

    public void unRide()
    {
        rideState = false;
        passiveDrive();
    }

    public void activeDrive()
    {
        player.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        plyFollowCar = true;
        driver.SetActive(true);
        cmCam.Follow = car.transform;
        cmCam.LookAt = carCamRoot;
        player.GetComponent<playerController>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        car.GetComponent<inputManager>().enabled = true;
        car.GetComponent<controller>().enabled = true;
        car.GetComponent<carModifier>().enabled = true;
        car.GetComponent<carEffects>().enabled = true;
        car.GetComponent<audio>().enabled = true;
    }

    public void passiveDrive()
    {
        player.transform.localScale = new Vector3(1f, 1f, 1f);
        player.transform.position = new Vector3(car.transform.position.x+inX , car.transform.position.y + inY, car.transform.position.z+inZ);
        plyFollowCar = false;
        driver.SetActive(false);
        cmCam.Follow = player.transform;
        cmCam.LookAt = playerCamRoot;
        player.GetComponent<playerController>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        car.GetComponent<inputManager>().enabled = false;
        car.GetComponent<controller>().enabled = false;
        car.GetComponent<carModifier>().enabled = false;
        car.GetComponent<carEffects>().enabled = false;
        car.GetComponent<audio>().enabled = false;
    }

    public void setCamera()
    {

    }

    void Start()
    {
    
    }
    
    void Update()
    {
        if (plyFollowCar)
        {
            player.transform.position = gameObject.transform.position;
        }
    }
    
}
