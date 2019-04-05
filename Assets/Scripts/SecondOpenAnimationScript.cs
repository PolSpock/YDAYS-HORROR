using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecondOpenAnimationScript : MonoBehaviour
{

    public Light mainLight;
    public Light openAnimationLight;

    // Locker 6 objets
    public GameObject numberNine_Locker3;
    public GameObject handler_Locker3;

    private AudioSource source;
    public AudioClip[] clips;

    public GameObject locker_number9;

    public GameObject player;

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
        Debug.Log("Second Open Animation");

        // On lance le son sourd
        AudioClip clip = clips.FirstOrDefault(c => c.name == "bruitSourd");
        source.clip = clip;
        source.Play();
        source.PlayOneShot(clip);

        AudioClip clip2 = clips.FirstOrDefault(c => c.name == "bruitScintillementLumiere");
        source.clip = clip2;
        source.Play();
        source.SetScheduledEndTime(AudioSettings.dspTime + (10f - 6f));
        source.PlayOneShot(clip2);

        player.GetComponent<SoundsOnPlayerScript>().RunSlowToFastHeartSound();

        // On éteint la lumière
        mainLight.enabled = false;
        RenderSettings.ambientIntensity = 0.35f;

        openAnimationLight.GetComponent<BlinkingLight>().maxIntensity = 10;
        openAnimationLight.GetComponent<BlinkingLight>().totalSeconds = 0.15f;

        openAnimationLight.GetComponent<Light>().enabled = true;

        // On cache le numéro 9 du casier
        locker_number9.GetComponent<MeshRenderer>().enabled = false;

        // Dans 5 secondes, on ferme le casier
        StartCoroutine(NextPhase());
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(5);
        print(Time.time);

        // On joue la fermuture casier
        Animation animation = GetComponent<Animation>();
        animation["Take 002"].speed = 3.5f;
        animation.Play("Take 002");

        AudioClip clip2 = clips.FirstOrDefault(c => c.name == "fermetureCasier");
        source.clip = clip2;
        source.Play();
        source.PlayOneShot(clip2);

        // On active le chiffre 9 sur l'autre casier
        numberNine_Locker3.GetComponent<MeshRenderer>().enabled = true;

        // On active les intéractions de l'autre casier
        handler_Locker3.GetComponent<ThirdLockerScript>().activate = true;

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
