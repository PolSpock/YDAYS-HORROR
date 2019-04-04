using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmbianceSoundsScript : MonoBehaviour
{
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

    public void RunMusiqueAmbiancePesante()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "musiqueAmbiancePesante");
        source.loop = true;
        source.volume = 0.05f;
        source.clip = clip;
        source.Play();
    }

    public void RunBruitDisjoncteur()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "bruitDisjoncteur");
        source.loop = false;
        source.volume = 0.1f;
        source.clip = clip;
        source.PlayOneShot(clip);
    }
}
