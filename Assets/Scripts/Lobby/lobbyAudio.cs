using UnityEngine;
using System.Collections;

//МУЗЫКА В ЛОББИ
[RequireComponent(typeof(AudioSource))]
public class lobbyAudio : MonoBehaviour {
       
      public AudioClip mainTheme;

      void OnEnable()
        {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();           
        audio.clip = mainTheme;
        audio.Play(); 
        }

    }
