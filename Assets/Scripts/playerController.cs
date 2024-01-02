using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    float inputX, inputY;
    float maxSpeed=1f;
    float normalFov;
    Vector3 stickDirection;
    Camera mainCam;
    Animator anim;

    [Header("publicler")]
    public float damp;
    public float sprintFov;
    public Transform model;
    [Range(1, 20)] public float rotationSpeed;
    [Range(1, 20)] public float strafeTurnSpeed;
    public KeyCode sprintButton = KeyCode.LeftShift, walkButton = KeyCode.C,flashButton=KeyCode.CapsLock;

    public float flashSpeed=3f;
    public GameObject flashEffect;

    public AudioClip[] SoundEffects;
    AudioSource au;

    bool isWalking = false;

    public enum moveType
    {
        Directional,
        Strafe
    };
    public moveType hareketTipi=moveType.Directional;

    void Start()
    {
        anim = GetComponent<Animator>();
        au = GetComponent<AudioSource>();
        mainCam =Camera.main;
        normalFov = mainCam.fieldOfView;
    }

    private void Update()
    {
        Movement();
        PlayMoveSound();
    }

    void Movement()
    {
        if (hareketTipi == moveType.Directional)
        {
            inputMove();
            inputRotate();
            
            stickDirection = new Vector3(inputX, 0f, inputY);

            if ( Input.GetKey(flashButton))
            {
                mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);
                maxSpeed = flashSpeed;
                inputX = 3 * Input.GetAxis("Horizontal");
                inputY = 3 * Input.GetAxis("Vertical");
                flashEffect.SetActive(true);
            }
            else 
            {
                if(flashEffect.activeSelf)
                flashEffect.SetActive(false);

                if (Input.GetKey(sprintButton))
                {
                    mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, sprintFov, Time.deltaTime * 2);
                    maxSpeed = 2f;
                    inputX = 2 * Input.GetAxis("Horizontal");
                    inputY = 2 * Input.GetAxis("Vertical");
                }
                else if (Input.GetKey(walkButton))
                {
                    mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                    maxSpeed = 0.2f;
                    inputX = Input.GetAxis("Horizontal");
                    inputY = Input.GetAxis("Vertical");
                }
                else
                {
                    mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, normalFov, Time.deltaTime * 2);
                    maxSpeed = 1f;
                    inputX = Input.GetAxis("Horizontal");
                    inputY = Input.GetAxis("Vertical");
                }
            }
        }
    }

    void inputMove()
    {
        anim.SetFloat("speed", Vector3.ClampMagnitude(stickDirection, maxSpeed).magnitude, damp, 10 * Time.deltaTime);
    }

    void inputRotate()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(stickDirection);
        rotOfset.y = 0;
        model.forward = Vector3.Slerp(model.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }

    void PlayMoveSound()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isMoving = Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0;
        bool isRunning = Input.GetKey(sprintButton);

        if (isMoving)
        {
            if (Input.GetKey(flashButton))
            {
                PlaySound(2); 
            }
            else if (isRunning)
            {
                PlaySound(1); 
            }
            else if (!isWalking)
            {
                PlaySound(0); 
            }
        }
        else if (!isMoving)
        {
            StopSound();
        }
    }

    void PlaySound(int index)
    {
        if (au.isPlaying && au.clip == SoundEffects[index]) return;
        au.clip = SoundEffects[index];
        au.Play();
        isWalking = true;
    }

    void StopSound()
    {
        au.Stop();
        au.clip = null;
        isWalking = false;
    }
}