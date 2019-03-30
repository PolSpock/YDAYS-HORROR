using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenAnimationScript : MonoBehaviour
{

    public Light mainLight;

    public GameObject numberNine;

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
        // On lance le son sourd
        AudioClip clip = clips.FirstOrDefault(c => c.name == "bruitSourd");
        source.clip = clip;
        source.Play();

        // On éteint la lumière
        mainLight.enabled = false;

        // Dans 5 secondes, on ferme le casier
        StartCoroutine(NextPhase());

        Animation animation = GetComponent<Animation>();
        animation["Take 002"].speed = 4.5f;
        animation.Play("Take 002");

        // On joue la fermuture casier
        AudioClip clip2 = clips.FirstOrDefault(c => c.name == "fermetureCasier");
        source.clip = clip2;
        source.Play();

        // On active le chiffre 9 sur l'autre casier
        numberNine.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator NextPhase()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
