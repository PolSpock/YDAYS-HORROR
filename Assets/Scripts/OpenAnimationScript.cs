using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenAnimationScript : MonoBehaviour
{

    public Light mainLight;
    public Light openAnimationLight;

    // Locker 6 objets
    public GameObject numberNine_Locker6;
    public GameObject handler_Locker6;

    private AudioSource source;
    public AudioClip[] clips;

    public GameObject locker_number9;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // L'animation d'ouverture est terminée
    public void PrintEvent()
    {
        Debug.Log("animation terminée, OpenAnimationScript");

        // On cache le numéro 9
        locker_number9.GetComponent<MeshRenderer>().enabled = false;

        // On lance le son sourd
        AudioClip clip = clips.FirstOrDefault(c => c.name == "bruitSourd");
        source.clip = clip;
        source.Play();
        source.PlayOneShot(clip);

        // On éteint la lumière
        mainLight.enabled = false;
        RenderSettings.ambientIntensity = 0.35f;

        // On joue le bruit scintillement lumière
        AudioClip clip2 = clips.FirstOrDefault(c => c.name == "bruitScintillementLumiere");
        source.clip = clip2;
        source.Play();
        source.SetScheduledEndTime(AudioSettings.dspTime + (10f - 6f));
        source.PlayOneShot(clip2);

        openAnimationLight.GetComponent<Light>().enabled = true;

        // On retire les chiffres de tous les autres objets
        GameObject[] lockersNumber = GameObject.FindGameObjectsWithTag("locker_number");
        foreach (GameObject lockerNumber in lockersNumber)
        {
            lockerNumber.GetComponent<MeshRenderer>().enabled = false;
        }

        StartCoroutine(NextPhase());
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(7);
        print(Time.time);

        Animation animation = GetComponent<Animation>();
        animation["Take 002"].speed = 3.5f;
        animation.Play("Take 002");

        // On joue la fermuture casier
        AudioClip clip3 = clips.FirstOrDefault(c => c.name == "fermetureCasier");
        source.clip = clip3;
        source.Play();
        source.PlayOneShot(clip3);

        // On active le chiffre 9 sur l'autre casier
        numberNine_Locker6.GetComponent<MeshRenderer>().enabled = true;

        // On active les intéractions de l'autre casier
        handler_Locker6.GetComponent<SecondLockerScript>().activate = true;

        StartCoroutine(NextLightPhase());
    }

    IEnumerator NextLightPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1.5f);
        print(Time.time);

        // On rallume la lumière
        mainLight.enabled = true;
        RenderSettings.ambientIntensity = 1f;
        openAnimationLight.GetComponent<Light>().enabled = false;
    }

}
