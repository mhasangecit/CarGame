using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public GameObject makerPanel;
    public GameObject blackPanel;
    Animator mp;
    Animator bp;
    AudioSource au;

    private void Start()
    {
        mp = makerPanel.GetComponent<Animator>();
        bp = blackPanel.GetComponent<Animator>();
        au=GetComponent<AudioSource>();
        StartCoroutine(closeBlackPanel());
    }

    public void play()
    {
        au.Play();
        blackPanel.SetActive(true);
        bp.SetInteger("fade",1);
        StartCoroutine(openScene(1));
    }

    public void maker()
    {
        mp.SetTrigger("open");
        au.Play();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void linkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/muhammed-hasan-gecit-78176b237/");
    }

    public void backMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator openScene(int scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    IEnumerator closeBlackPanel()
    {
        yield return new WaitForSeconds(1f);
        blackPanel.SetActive(false);
    }

    public void repeat()
    {
        au.Play();
        SceneManager.LoadScene(1);
    }
}
