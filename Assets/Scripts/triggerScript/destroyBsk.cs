using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBsk : MonoBehaviour { 

    public GameObject baskan;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("baskan"))
        {
            Destroy(baskan);
        }
    }
}
