using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlCrossedHall : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public Light light3;

    public Text canvasText;

    public GameObject VRPlayer;

    public GameObject environment;

    public GameObject tableNextScreamer;

    // Start is called before the first frame update
    void Start()
    {
        VRPlayer.transform.position = new Vector3(-1.768f, -11.903f, -30.166f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter Collision");

        Debug.Log(col.gameObject);

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Switch Trigger");

        if (col.gameObject.name == "Walking")
        {

            col.gameObject.GetComponent<AudioSource>().Stop();

            environment.GetComponent<AmbianceSoundsScript>().RunBruitDisjoncteur();

            light1.enabled = false;
            light2.enabled = false;
            light3.enabled = false;

            col.gameObject.SetActive(false);

            RenderSettings.ambientIntensity = 0.45f;

            StartCoroutine(NextPhase());

        }
    }

    private IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);

        VRPlayer.GetComponent<SoundsOnPlayerScript>().RunMamanFroidSound();

        canvasText.text = "Maman... J'ai froid...";

        VRPlayer.transform.position = new Vector3(-1.768f, -11.903f, -30.166f);

        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        foreach (GameObject camera in cameras)
        {
            camera.transform.rotation = Quaternion.Euler(45, 0, 0);
        }


        StartCoroutine(NextNextPhase());

    }

    private IEnumerator NextNextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(13f);
        print(Time.time);

        tableNextScreamer.GetComponent<SecondScreamerScript>().StartSecondScreamerScript();
    }
}