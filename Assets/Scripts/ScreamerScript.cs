using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerScript : MonoBehaviour
{
    public Boolean hasPlayed = false;
    public Boolean hasEnteredTrigger = false;
    public AudioClip screamingSound;

    public GameObject screamer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        screamer.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnteredTrigger == true && !hasPlayed)
        {
            screamer.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(RemoveOvertime());
            MakeHimScream();
        }
    }

    public void StartScreamer()
    {
        hasEnteredTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        hasEnteredTrigger = true;
    }

    private IEnumerator RemoveOvertime()
    {
        yield return new WaitForSeconds(1.5f);
        screamer.GetComponent<MeshRenderer>().enabled = false;
    }

    private void MakeHimScream()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            audioSource.PlayOneShot(screamingSound, 1f);
        }
    }
}
