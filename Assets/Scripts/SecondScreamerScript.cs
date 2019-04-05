using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScreamerScript : MonoBehaviour
{
    public GameObject boiteMusique;
    public GameObject VRPlayer;
    public GameObject screamer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSecondScreamerScript()
    {
        Debug.Log("SECOND SCREAMER");

        // On affiche la boite à musique
        GameObject[] morceauxBoiteMusique = GameObject.FindGameObjectsWithTag("boite_musique");
        foreach (GameObject morceau in morceauxBoiteMusique)
        {
            morceau.GetComponent<MeshRenderer>().enabled = true;
        }

        // On joue la musique
        AudioSource audioSource = boiteMusique.GetComponent<AudioSource>();
        audioSource.time = 59f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (76f - 59f));

        StartCoroutine(NextPhase());
    }

    private IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(12f);
        print(Time.time);

        VRPlayer.GetComponent<SoundsOnPlayerScript>().RunMamanSound();

        // On affiche le screamer
        GameObject[] girlParts = GameObject.FindGameObjectsWithTag("second_screamer");
        foreach (GameObject girlPart in girlParts)
        {
            girlPart.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }

        Animation animation = screamer.GetComponent<Animation>();
        animation["Take 001"].speed = 1.5f;
        animation.Play("Take 001");
    }
}
