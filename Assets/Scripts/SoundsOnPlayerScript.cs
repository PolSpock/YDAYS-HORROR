using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundsOnPlayerScript : MonoBehaviour
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

    public void RunSlowToFastHeartSound()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "slowToFastHeart");
        source.clip = clip;
        source.Play();
    }

    public void RunMamanFroidSound()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "mamanFroid");
        source.clip = clip;
        source.Play();
    }

    public void RunMamanSound()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "maman");
        source.clip = clip;
        source.Play();
    }
}
