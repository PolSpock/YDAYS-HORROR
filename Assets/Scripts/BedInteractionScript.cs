using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BedInteractionScript : MonoBehaviour
{
    private bool hasClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject drapFace = GameObject.FindGameObjectWithTag("drap_face_enabled");
        drapFace.GetComponent<MeshRenderer>().enabled = false;
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

        GameObject drapFace = GameObject.FindGameObjectWithTag("drap_face_enabled");
        drapFace.GetComponent<MeshRenderer>().enabled = true;

        GetComponent<MeshRenderer>().enabled = false;
    }


    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

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
