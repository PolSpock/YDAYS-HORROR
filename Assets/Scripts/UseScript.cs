using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UseScript : MonoBehaviour
{
    //Name this variable "ShowText" then drag the "ShowText" script into the variable through the inspector.
    public ShowTextScript textDisplayingScript;
    public ScreamerScript screamerScript;

    public GameObject bouton1;
    public GameObject bouton2;
    public GameObject bouton3;

    // Start is called before the first frame update
    void Start()
    {
        textDisplayingScript.DisplayTextHereFor("Bon...j’aimerai voir son visage une dernière fois, elle doit être sous ces draps...", 10, 50, 10);

        //bouton2.SetActive(false);
        bouton2.GetComponent<MeshRenderer>().enabled = false;

        //bouton3.SetActive(false);
        bouton3.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f))
            {
                Debug.Log("touché");
                Debug.Log(hit.transform.gameObject);

               if (hit.transform.tag == "bedInteraction")
               {
                    Debug.Log("Je suis bedInteraction");

                    screamerScript.StartScreamer();

                    //Shows two lines of text at the bottom left of the screen (10 pixels from the left and 50 from the bottom).
                    //The text lasts for 5 seconds before it disappears.
                    textDisplayingScript.DisplayTextHereFor("Elle doit surement être dans les casiers, la dernière fois elle l’a sortie du n°9...", 10, 50, 10);
                }

                if (hit.transform.tag == "lockerInteraction")
                {
                    Debug.Log("Je suis lockerInteraction");
                }
            }
        }
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
        //put your stuff here
        print("Success");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f))
        {
            Debug.Log("touché");
            Debug.Log(hit.transform.gameObject);

            if (hit.transform.tag == "bouton1")
            {
                Debug.Log("Je suis bouton1");
                //hit.transform.gameObject.SetActive(false);
                //bouton1.SetActive(false);
                bouton1.GetComponent<MeshRenderer>().enabled = false;

                //bouton2.SetActive(true);
                bouton2.GetComponent<MeshRenderer>().enabled = true;

            }
            else if (hit.transform.tag == "bouton2")
            {
                Debug.Log("Je suis bouton2");
                //hit.transform.gameObject.SetActive(false);
                //bouton2.SetActive(false);
                bouton2.GetComponent<MeshRenderer>().enabled = false;

                //bouton3.SetActive(true);
                bouton3.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
