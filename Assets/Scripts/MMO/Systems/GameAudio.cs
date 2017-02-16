using UnityEngine;
using System.Collections;

//ОПИСАНИЕ музыка в игре
//ПРИКРЕПЛЕН К ММО

public class GameAudio : MonoBehaviour {

    public AudioClip[] spaceThemes; //музыка, космотемы
    private AudioSource audioSource;

    void Start () {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }

    private AudioClip GetRandomClip()
    {
        return spaceThemes[Random.Range(0, spaceThemes.Length)];
    }
	
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
	
	}
}
