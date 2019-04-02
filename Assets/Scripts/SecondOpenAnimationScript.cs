using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecondOpenAnimationScript : MonoBehaviour
{

    public Light mainLight;

    // Locker 6 objets
    public GameObject numberNine_Locker3;
    public GameObject handler_Locker3;

    private AudioSource source;
    public AudioClip[] clips;


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

        // On éteint la lumière
        mainLight.enabled = false;

        // Dans 5 secondes, on ferme le casier
        StartCoroutine(NextPhase());

        // On joue la fermuture casier
        Animation animation = GetComponent<Animation>();
        animation["Take 002"].speed = 4.5f;
        animation.Play("Take 002");

        AudioClip clip2 = clips.FirstOrDefault(c => c.name == "fermetureCasier");
        source.clip = clip2;
        source.Play();

        // On active le chiffre 9 sur l'autre casier
        numberNine_Locker3.GetComponent<MeshRenderer>().enabled = true;

        // On active les intéractions de l'autre casier
        handler_Locker3.GetComponent<ThirdLockerScript>().activate = true;
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
