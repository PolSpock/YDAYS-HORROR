
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FirstScreamerScript : MonoBehaviour
{
    private bool hasClicked = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public GameObject screamerObj_VR;

    public GameObject corps_ontable;
    public GameObject corps_drap2;
    public GameObject corps_drap3;

    public GameObject locker_3;

    public GameObject player;

    public Light mainLight;
    public Light openAnimationLight;

    public GameObject poigne_3;

    public GameObject handlePorte;

    // Start is called before the first frame update
    void Start()
    {
        /*
       Debug.Log("SCREAMER");

       Animation animation = screamerObj_VR.GetComponent<Animation>();
       animation["Take 001"].speed = 6f;
       animation.Play("Take 001");

       animation = screamerObj_NOVR.GetComponent<Animation>();
       animation["Take 001"].speed = 6f;
       animation.Play("Take 001");

       GameObject[] girlParts = GameObject.FindGameObjectsWithTag("locker_screamer");
       foreach (GameObject girlPart in girlParts)
       {
           girlPart.GetComponent<SkinnedMeshRenderer>().enabled = true;
       }
       */

        // On désaffiche le sang
        GameObject[] bloods = GameObject.FindGameObjectsWithTag("bloods");
        foreach (GameObject blood in bloods)
        {
            blood.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Switch Collision");

    }


    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Switch Trigger");

        //if (hasClicked)
        //{
            Debug.Log("SCREAMER");

            //screamerObj_VR.GetComponent<MeshRenderer>().enabled = true;
            //screamerObj_NOVR.GetComponent<MeshRenderer>().enabled = true;

            // On déactive le cube
            GetComponent<Animator>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

            Animation animation = screamerObj_VR.GetComponent<Animation>();
            animation["Take 001"].speed = 2.5f;
            animation.Play("Take 001");

            // On désactive la poignée
            poigne_3.SetActive(false);

            //player.GetComponent<SoundsOnPlayerScript>().RunSlowToFastHeartSound();

            StartCoroutine(NextPhase());

            /*
            animation = screamerObj_NOVR.GetComponent<Animation>();
            animation["Take 001"].speed = 6f;
            animation.Play("Take 001");
            */

            /*
            GameObject[] girlParts = GameObject.FindGameObjectsWithTag("locker_screamer");
            foreach (GameObject girlPart in girlParts)
            {
                girlPart.GetComponent<SkinnedMeshRenderer>().enabled = true;
            }
            */


            //screamerObj_VR.GetComponent<MeshRenderer>().enabled = false;
            //screamerObj_NOVR.GetComponent<MeshRenderer>().enabled = false;

            /*
            foreach (GameObject girlPart in girlParts)
            {
                girlPart.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            */



            // On joue la fermuture casier
            //Animation animation_locker3 = locker_3.GetComponent<Animation>();
            //animation_locker3["Take 002"].speed = 4.5f;
            //animation_locker3.Play("Take 002");


            //}
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1f);
        print(Time.time);

        mainLight.enabled = false;
        RenderSettings.ambientIntensity = 0.55f;
        openAnimationLight.GetComponent<Light>().enabled = true;

        StartCoroutine(ScreamerYellPhase());
    }

    private IEnumerator ScreamerYellPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(5f);
        print(Time.time);

        screamerObj_VR.GetComponent<AudioSource>().Play();

        StartCoroutine(EndPhase());
    }

    private IEnumerator EndPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1f);
        print(Time.time);

        openAnimationLight.GetComponent<Light>().enabled = false;
        RenderSettings.ambientIntensity = 0f;

        Animation animation = locker_3.GetComponent<Animation>();
        animation["Take 002"].speed = 3f;
        animation.Play("Take 002");

        locker_3.GetComponent<ThirdLockerSoundScript>().RunClaquementFermetureCasier();

        // On enlève le corps sur la table
        corps_ontable.GetComponent<MeshRenderer>().enabled = false;
        corps_drap2.GetComponent<MeshRenderer>().enabled = false;

        // On affiche le drap
        corps_drap3.GetComponent<MeshRenderer>().enabled = true;

        // On affiche le sang
        GameObject[] bloods = GameObject.FindGameObjectsWithTag("bloods");
        foreach (GameObject blood in bloods)
        {
            blood.GetComponent<MeshRenderer>().enabled = true;
        }

        StartCoroutine(EndEndPhase());
    }

    private IEnumerator EndEndPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(0.75f);
        print(Time.time);

        // On désaffiche le screamer
        screamerObj_VR.SetActive(false);

        StartCoroutine(EndEndEndPhase());
    }

    private IEnumerator EndEndEndPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(2f);
        print(Time.time);

        handlePorte.GetComponent<Animator>().enabled = true;
        handlePorte.GetComponent<AudioSource>().Play();

        mainLight.enabled = true;
        RenderSettings.ambientIntensity = 1f;
        openAnimationLight.GetComponent<Light>().enabled = false;
    }


    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Unpress, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        hasClicked = true;
    }

    private void Unpress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        hasClicked = false;
   
    }
}
