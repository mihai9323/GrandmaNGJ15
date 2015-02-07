using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public static SoundManager s_Instance;
	
	
	public AudioClip[] pillSounds;
	public AudioClip[] punchSounds;
	
	public static AudioClip returnRandomSound(AudioClip[] soundsArray){
		if(soundsArray != null && soundsArray.Length>0){
			return soundsArray[Random.Range(0,soundsArray.Length)];
		}else return null;
	}
}
