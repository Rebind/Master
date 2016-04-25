using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public AudioClip attachSound;
	public AudioClip detachSound;

    public AudioClip detachSoundLeg;
    public AudioClip detachSoundArm;
    public AudioClip detachSoundTorso;

    public AudioClip headRoll;
	public AudioClip torsoWalk;
	public AudioClip footsteps;
	public AudioClip feet;
	public AudioClip jump;
    public AudioClip limbControl;
    public AudioClip dead;
    public AudioClip climb;


    public AudioSource audioAttach;
    public AudioSource audioLimbControl;
    public AudioSource audioClimb;
    public AudioSource audiodead;
    public AudioSource audioDetach;

    public AudioSource audioDetachLeg;
    public AudioSource audioDetachArm;
    public AudioSource audioDetachTorso;

    public AudioSource audioHeadRoll;
	public AudioSource audioTorso;
	public AudioSource audioFoot;
	public AudioSource audioFeet;
	public AudioSource audioJump;
	public AudioSource[] playerMovementAudioSources;


	public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) { 
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip; 
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol; 
		return newAudio; 
	}

	public void Awake(){
		// add the necessary AudioSources:
		audioAttach = AddAudio(attachSound, false, true, 0.5f);

        audioDetachLeg = AddAudio(detachSoundLeg, false, true, 0.5f);
        audioDetachArm = AddAudio(detachSoundArm, false, true, 0.5f);
        audioDetachTorso = AddAudio(detachSoundTorso, false, true, 0.5f);

        audioDetach = AddAudio(detachSound, false, true, 0.5f);
		audioHeadRoll = AddAudio(headRoll, false, true, 2.0f); 
		audioTorso = AddAudio(torsoWalk, false, true, 0.2f); 
		audioFoot = AddAudio(footsteps, true, true, 0.1f);
		//audioFoot.pitch = 0.35f;
		audioFeet = AddAudio(feet, true, true, 3.0f);
		audioJump = AddAudio(jump, false, true,.5f);
        audiodead = AddAudio(dead, false, true, .6f);
        audioLimbControl = AddAudio(limbControl, false, true, .4f);
        audioClimb = AddAudio(climb, false, true, 1f);

        playerMovementAudioSources = new AudioSource[4] { audioHeadRoll, audioTorso, audioFeet, audioFoot };
	} 
}