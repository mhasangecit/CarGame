using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDialog : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource audioSource;
    public bool speak;
    public int soundCount;
    public GameObject player;
    int i = -1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        if (speak && !audioSource.isPlaying)
        {
            GetComponent<Animator>().SetBool("speak", true);
            StartCoroutine(playSoundUntilEnd());
        }
    }

    IEnumerator playSoundUntilEnd()
    {
        i++;
        if (i >= soundCount) i = 0;
        audioSource.PlayOneShot(audios[i]);
        yield return new WaitForSeconds(audios[i].length);
        GetComponent<Animator>().SetBool("speak", false);
        speak = false;
    }
}
