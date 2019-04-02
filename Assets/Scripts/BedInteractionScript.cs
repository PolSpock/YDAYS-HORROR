using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class BedInteractionScript : MonoBehaviour
{
    private bool hasClicked = false;
    public GameObject drap_closed;
    public GameObject drap_opened;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public AudioSource battementCoeur;

    public Text canvasText;

    // Start is called before the first frame update
    void Start()
    {
        drap_opened.GetComponent<MeshRenderer>().enabled = false;
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
            GetComponent<MeshRenderer>().enabled = false;

            drap_opened.GetComponent<MeshRenderer>().enabled = true;

            drap_closed.GetComponent<MeshRenderer>().enabled = false;



            canvasText.text = "Elle doit surement être dans les casiers, la dernière fois elle l’a sortie du n°9...";

            battementCoeur.loop = true;
            battementCoeur.Play();
        };
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
