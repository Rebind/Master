using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource myaudio;

	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        myaudio = GetComponent<AudioSource>();
        myaudio.clip = movie.audioClip;
        movie.Play();
        myaudio.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
