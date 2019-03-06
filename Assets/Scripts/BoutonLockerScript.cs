using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BoutonLockerScript : MonoBehaviour
{
    private bool hasClicked = false;
    public GameObject bouton2;

    // Start is called before the first frame update
    void Start()
    {
        bouton2.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Switch Collision");

        if (hasClicked)
        {
            GetComponent<MeshRenderer>().enabled = false;
            bouton2.GetComponent<MeshRenderer>().enabled = true;
        }

    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Switch Trigger");
    }


    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Pressed");
        Debug.Log(fromAction);
        Debug.Log(fromSource);
        hasClicked = true;

        Debug.Log("----- end -----");
    }
}
