using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThirdLockerSoundScript : MonoBehaviour
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

    public void RunClaquementFermetureCasier()
    {
        // On lance le 
        AudioClip clip = clips.FirstOrDefault(c => c.name == "claquementFermetureCasier");
        source.clip = clip;
        source.Play();
        source.PlayOneShot(clip);
    }
}
