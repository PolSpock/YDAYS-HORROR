using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LockerScript : MonoBehaviour
{
    public GameObject locker;
    private bool hasClicked = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

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
            locker.GetComponent<Animation>().Play("Take 001");
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
