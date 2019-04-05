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
        source.Stop();

        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "slowToFastHeart");
        source.loop = true;
        source.clip = clip;
        source.Play();
    }

    public void RunMamanFroidSound()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "mamanFroid");
        source.loop = false;
        source.clip = clip;
        source.Play();
        source.PlayOneShot(clip);
    }

    public void RunMamanSound()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "maman");
        source.loop = false;
        source.clip = clip;
        source.Play();
        source.PlayOneShot(clip);
    }
}
