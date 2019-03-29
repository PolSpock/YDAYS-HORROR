using System;
using System.Linq;
using UnityEngine;

public class soundScript : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioClip clip = clips.FirstOrDefault(c => c.name == "battementCoeur");
        AudioClip clip02 = clips.FirstOrDefault(c => c.name == "bruitDisjoncteur");
        AudioClip clip03 = clips.FirstOrDefault(c => c.name == "screamerFille");

        if(clip03 != null)
        {
            source.volume = 1f;
            source.loop = true;
        }

        source.clip = clip03;
        source.Play();
        //source.PlayOneShot(clip02);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
