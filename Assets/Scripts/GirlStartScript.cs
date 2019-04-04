using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GirlStartScript : MonoBehaviour
{
    private bool hasClicked = false;
    public GameObject GirlWalking;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public GameObject LightHall;

    // Start is called before the first frame update
    void Start()
    {
        //GirlWalking.GetComponent<GirlWalkScript>().isEnabled = true;
        GameObject[] members = GameObject.FindGameObjectsWithTag("petite_fille_members");
        foreach (GameObject member in members)
        {
            member.GetComponent<SkinnedMeshRenderer>().enabled = false;
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
            GetComponent<Animator>().enabled = false;

            GetComponent<AudioSource>().Play();

            GirlWalking.GetComponent<GirlWalkScript>().isEnabled = true;
            GameObject[] members = GameObject.FindGameObjectsWithTag("petite_fille_members");
            foreach (GameObject member in members)
            {
                member.GetComponent<SkinnedMeshRenderer>().enabled = true;
            }

            Animation animation = GirlWalking.GetComponent<Animation>();
            animation.Play("mixamo.com");

            GirlWalking.GetComponent<AudioSource>().Play();

            LightHall.GetComponent<Light>().enabled = true;

        //}


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
