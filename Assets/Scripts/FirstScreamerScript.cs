using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FirstScreamerScript : MonoBehaviour
{
    private bool hasClicked = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public Camera plyCamera;
    public GameObject screamerObj_VR;
    public GameObject screamerObj_NOVR;

    public GameObject corps_ontable;
    public GameObject corps_drap2;
    public GameObject corps_drap3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SCREAMER");

        //Instantiate(screamerObj, plyCamera.transform.position + plyCamera.transform.forward * 2.25f + plyCamera.transform.up *1 + plyCamera.transform.right * -0.10f, Quaternion.Euler(new Vector3(90, 90, 0)));

        //Vector3 SpawnPosition = plyCamera.transform.forward * 5 + plyCamera.transform.position;
        //Instantiate(screamerObj, SpawnPosition, Quaternion.identity);

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
            Debug.Log("SCREAMER");

            screamerObj_VR.GetComponent<MeshRenderer>().enabled = true;
            screamerObj_NOVR.GetComponent<MeshRenderer>().enabled = true;

            StartCoroutine(NextPhase());

            screamerObj_VR.GetComponent<MeshRenderer>().enabled = false;
            screamerObj_NOVR.GetComponent<MeshRenderer>().enabled = false;

            // On enlève le corps sur la table
            corps_ontable.GetComponent<MeshRenderer>().enabled = false;
            corps_drap2.GetComponent<MeshRenderer>().enabled = false;

            // On affiche le drap
            corps_drap3.GetComponent<MeshRenderer>().enabled = true;

        }
    }

    private IEnumerator NextPhase()
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
