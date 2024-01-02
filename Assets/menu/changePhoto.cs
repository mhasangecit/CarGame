using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePhoto : MonoBehaviour
{
    public Sprite[] images;
    public GameObject picBg;
    public float changeTime = 10f;
    Animator anm;
    Image spr;
    Image bgSpr;

    float timer = 0f;
    int i = 0;
    int j = 0;

    void Start()
    {
        anm = GetComponent<Animator>();
        spr = GetComponent<Image>();
        bgSpr = picBg.GetComponent<Image>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (i >= images.Length)
        {
            i = 0;
            j = 0;
        }

        if (timer >= changeTime)
        {
            print("change");
            spr.sprite = images[i];
            i++;
            anm.SetTrigger("fade");
            StartCoroutine(bgChng());
            timer = 0f;
        }
    }

    IEnumerator bgChng()
    {
        yield return new WaitForSeconds(1f);
        bgSpr.sprite = images[j];
        j++;
    }
}
