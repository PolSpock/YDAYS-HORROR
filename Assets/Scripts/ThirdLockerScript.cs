using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ThirdLockerScript : MonoBehaviour
{
    public GameObject locker;
    private bool hasClicked = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public bool activate = false;

    public GameObject poigne_casier_troisieme;

    public GameObject envrionment;

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

        //if (activate && hasClicked)
        //{
            Animation animation = locker.GetComponent<Animation>();
            animation["Take 001"].speed = 2f;
            animation.Play("Take 001");

            AudioSource audioSource = locker.GetComponent<AudioSource>();
            audioSource.Play();

            StartCoroutine(NextPhase());
        //}
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);

        // On déssaffiche la poignée après 5s
        poigne_casier_troisieme.GetComponent<Animator>().enabled = false;

        envrionment.GetComponent<AmbianceSoundsScript>().RunMusiqueAmbiancePesante();

        GetComponent<GameObject>().SetActive(false);
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
        hasClicked = true;

    }

    private void Unpress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        hasClicked = false;
    }


}
