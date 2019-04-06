using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScreamerScript : MonoBehaviour
{
    public GameObject boiteMusique;
    public GameObject VRPlayer;
    public GameObject noVr_screamer;
    public GameObject vr_screamer;

    public Light mainLight;

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

        StartCoroutine(NextPhase());
    }

    private IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(1f);
        print(Time.time);

        // On joue l'animation
        Animation animation = boiteMusique.GetComponent<Animation>();
        animation.Play("Take 001");

        // On joue la musique
        AudioSource audioSource = boiteMusique.GetComponent<AudioSource>();
        audioSource.time = 59f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (76f - 59f));

        mainLight.enabled = true;

        StartCoroutine(NextNextPhase());
    }

    private IEnumerator NextNextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(11f);
        print(Time.time);

        VRPlayer.GetComponent<SoundsOnPlayerScript>().RunMamanSound();

        // On affiche le screamer
        GameObject[] girlParts = GameObject.FindGameObjectsWithTag("second_screamer");
        foreach (GameObject girlPart in girlParts)
        {
            girlPart.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }

        Animation animation = noVr_screamer.GetComponent<Animation>();
        animation["Take 001"].speed = 1.5f;
        animation.Play("Take 001");

        animation = vr_screamer.GetComponent<Animation>();
        animation["Take 001"].speed = 1.5f;
        animation.Play("Take 001");

        StartCoroutine(NextNextNextPhase());
    }

    private IEnumerator NextNextNextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(4f);
        print(Time.time);

        noVr_screamer.GetComponent<AudioSource>().Play();
        vr_screamer.GetComponent<AudioSource>().Play();
    }

}
