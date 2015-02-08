using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public static SoundManager s_Instance;
	
	
	public AudioClip[] pillSounds;
	public AudioClip[] punchSounds;
	public AudioClip[] tireScreech;
	public AudioClip[] wheels;
	public AudioClip[] maleShout;
	public AudioClip[] femaleShout;
	public AudioClip[] nanaSounds;
	public AudioClip[] tableSounds;
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		StartCoroutine(NanaSound());
	}
	public static AudioClip returnRandomSound(AudioClip[] soundsArray){
		if(soundsArray != null && soundsArray.Length>0){
			return soundsArray[Random.Range(0,soundsArray.Length)];
		}else return null;
	}
	private IEnumerator NanaSound(){
		while(true){
			yield return new WaitForSeconds(Random.Range(10,30));
			new AudioSourcePoint(returnRandomSound(nanaSounds),transform.position,10,1,1);
		}
	}
}
