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

            //screamerObj_VR.GetComponent<MeshRenderer>().enabled = true;
            //screamerObj_NOVR.GetComponent<MeshRenderer>().enabled = true;

            Animation animation = screamerObj_VR.GetComponent<Animation>();
            animation["Take 001"].speed = 6f;
            animation.Play("Take 001");

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

            StartCoroutine(NextPhase());

            //screamerObj_VR.GetComponent<MeshRenderer>().enabled = false;
            //screamerObj_NOVR.GetComponent<MeshRenderer>().enabled = false;

            /*
            foreach (GameObject girlPart in girlParts)
            {
                girlPart.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            */

            // On enlève le corps sur la table
            corps_ontable.GetComponent<MeshRenderer>().enabled = false;
            corps_drap2.GetComponent<MeshRenderer>().enabled = false;

            // On affiche le drap
            corps_drap3.GetComponent<MeshRenderer>().enabled = true;


            // On joue la fermuture casier
            Animation animation_locker3 = locker_3.GetComponent<Animation>();
            animation_locker3["Take 002"].speed = 4.5f;
            animation_locker3.Play("Take 002");


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
