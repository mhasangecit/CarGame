using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miho : MonoBehaviour
{
    public AudioClip[] audi;
    public GameObject hio;
    public float turnSpeed;
    AudioSource mh;
    public GameObject seat;
    Animator anim;

    public float rotationSpeed = 90f; 
    private bool isRotating = false;

    void Start()
    {
        mh = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isRotating)
        {
            Vector3 targetDirection = transform.position - hio.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            float step = rotationSpeed * Time.deltaTime;
            hio.transform.rotation = Quaternion.RotateTowards(hio.transform.rotation, targetRotation, step);

            if (hio.transform.rotation == targetRotation)
            {
                isRotating = false;
            }
        }
    }

    public void amazedMiho()
    {
        StartRotation();
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        seat.GetComponent<Animator>().SetInteger("turn", 1);
        anim.SetBool("speak", true);
        mh.PlayOneShot(audi[0]);
        anim.SetBool("speak", true);
        yield return new WaitForSeconds(audi[0].length);
        anim.SetBool("speak", false);
        hio.GetComponent<AudioSource>().PlayOneShot(audi[1]);
        hio.GetComponent<Animator>().SetBool("speak", true);
        yield return new WaitForSeconds(audi[1].length);
        seat.GetComponent<Animator>().SetInteger("turn", 2);
        hio.GetComponent<Animator>().SetBool("speak", false);
    }

    public void StartRotation()
    {
        isRotating = true;
    }
}
