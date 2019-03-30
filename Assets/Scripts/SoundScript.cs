using System;
using System.Linq;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    /// <summary>
    /// Correspond au component AudioSource attaché à l'objet
    /// </summary>
    private AudioSource source;
    
    /// <summary>
    /// Contient tous les sons qui peuvent être joués pour l'objet attaché
    /// </summary>
    public AudioClip[] clips;

    /// <summary>
    /// Récupére le component de type AudioSource attaché à l'objet
    /// </summary>
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Dans cet exemple, on récupére un un par chaque clip présent dans clips dans une nouvelle variable de type AudioClip
        // Cela va nous permettre d'attacher à notre AudioSource le clip que l'on souhaite jouer
        AudioClip clip = clips.FirstOrDefault(c => c.name == "battementCoeur");
        AudioClip clip02 = clips.FirstOrDefault(c => c.name == "bruitDisjoncteur");
        AudioClip clip03 = clips.FirstOrDefault(c => c.name == "screamerFille");

        PlayClip(clip);
        PlayClip02(clip02);
        PlayClip03(clip03);

        //On attache à le clip à la source
        source.clip = clip03;
        //On active le son
        source.Play();
        //On active le son mais le son sera joué une fois mais si la propriété loop est activé
        source.PlayOneShot(clip02);

        //On peut arrêter les musiques qui tournent en boucle en faisant source.Stop()
        //(Voir toutes les méthodes que l'on peut utiliser avec la variable source de type AudioSource)
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    private void PlayClip(AudioClip clip)
    {
        // Si on récupére bien le clip, on peut ici modifier les comportements de la source avant de jouer un clip
        if (clip != null)
        {
            source.volume = 0.8f;
            source.loop = false;
        }
    }

    private void PlayClip02(AudioClip clip)
    {
        // Si on récupére bien le clip, on peut ici modifier les comportements de la source avant de jouer un clip
        if (clip != null)
        {
            source.volume = 0.4f;
            source.loop = true;
        }
    }

    private void PlayClip03(AudioClip clip)
    {
        // Si on récupére bien le clip, on peut ici modifier les comportements de la source avant de jouer un clip
        if (clip != null)
        {
            source.volume = 1f;
            source.loop = true;
        }
    }
}
