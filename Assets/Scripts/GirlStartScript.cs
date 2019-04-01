using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GirlStartScript : MonoBehaviour
{
    private bool hasClicked = false;
    public GameObject start;
    public GameObject[] members;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;
    
    // Start is called before the first frame update
    void Start()
    {
        members = GameObject.FindGameObjectsWithTag("petit_fille_members");
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

        if (hasClicked)
        {
            members = GameObject.FindGameObjectsWithTag("petit_fille_members");
            foreach (GameObject member in members)
            {
                member.GetComponent<SkinnedMeshRenderer>().enabled = true;
            }

            start.GetComponent<GirlWalkScript>().isEnabled = true;
        }


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
