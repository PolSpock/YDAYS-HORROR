﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LockerScript : MonoBehaviour
{
    public GameObject locker;
    private bool hasClicked = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public GameObject poigne_casier_premier;
    public GameObject poigne_casier_deuxieme;

    public GameObject locker_number9;

    // Start is called before the first frame update
    void Start()
    {

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

        if (hasClicked)
        {
            Animation animation = locker.GetComponent<Animation>();
            animation["Take 001"].speed = 2f;
            animation.Play("Take 001");

            AudioSource audioSource = locker.GetComponent<AudioSource>();
            audioSource.Play();

            // On retire les poignées & chiffres de tous les autres objets
            GameObject[] lockersNumber = GameObject.FindGameObjectsWithTag("locker_number");

            foreach(GameObject lockerNumber in lockersNumber)
            {
                lockerNumber.GetComponent<MeshRenderer>().enabled = false;
            }

            StartCoroutine(NextPhase());

            // On déssaffiche la poignée après 2s
            GameObject firstHandler = GameObject.FindGameObjectWithTag("first_handler");
            firstHandler.GetComponent<MeshRenderer>().enabled = false;

            poigne_casier_premier.GetComponent<Animator>().enabled = false;
            poigne_casier_deuxieme.GetComponent<Animator>().enabled = true;

            locker_number9.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
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
        Debug.Log("Pressed");
        Debug.Log(fromAction.state);
        Debug.Log(fromSource);
        hasClicked = true;

        Debug.Log("----- end -----");
    }

    private void Unpress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Unpressed");
        Debug.Log(fromAction.state);
        Debug.Log(fromSource);
        hasClicked = false;

        Debug.Log("----- end -----");
    }


}
