using UnityEngine;
using System.Collections;


public class Fist : MonoBehaviour {

	private void OnCollisionEnter(Collision col){
		switch(col.collider.tag){
			case "Pill": CollectPill(col.collider.gameObject); break;
		    case "Doctor": DoctorPunch(col.collider.gameObject,col.contacts[0].point); break;
		    case "Doctress": DoctressPunch(col.collider.gameObject,col.contacts[0].point); break;
		}
	}
	
	
	private void CollectPill(GameObject gob){
		World.Frenzy = true;
		Destroy(gob);
		gob.GetComponent<WorldObject>().lane.SpawnObject();
		new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.pillSounds),transform.position, 3.0f, 1.0f, Random.Range(.9f,1.5f));
		Debug.Log("pill");
	}
	private void DoctorPunch(GameObject gob, Vector3 point){
		World.TotalScore+= 1;
		if(this.tag == "Fist"){
			World.currentCombo=1;
		}else{
			World.currentCombo++;
			World.BestCombo = World.currentCombo;
		}
		gob.rigidbody.isKinematic = false;
		gob.rigidbody.AddForce(Vector3.forward * 2000,ForceMode.Force);
		if(!gob.GetComponent<Fist>())gob.AddComponent<Fist>();
		Destroy(gob,2.0f);
		gob.GetComponent<WorldObject>().lane.SpawnObject();
		new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.punchSounds),transform.position, 3.0f, 1.0f, Random.Range(.9f,1.5f));
		AudioSource AS = gob.AddComponent<AudioSource>();
		AS.clip = SoundManager.returnRandomSound(SoundManager.s_Instance.maleShout);
		AS.pitch = Random.Range(.95f,1.1f);
		AS.Play();
		
		
	}
	private void DoctressPunch(GameObject gob, Vector3 point){
		World.TotalScore+= 1;
		if(this.tag == "Fist"){
			World.currentCombo=1;
		}else{
			World.currentCombo++;
			World.BestCombo = World.currentCombo;
		}
		gob.rigidbody.isKinematic = false;
		if(!gob.GetComponent<Fist>())gob.AddComponent<Fist>();
		gob.rigidbody.AddForce(Vector3.forward * 2000,ForceMode.Force);
		Destroy(gob,2.0f);
		gob.GetComponent<WorldObject>().lane.SpawnObject();
		new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.punchSounds),transform.position, 3.0f, 1.0f, Random.Range(.9f,1.5f));
		AudioSource AS = gob.AddComponent<AudioSource>();
		AS.clip = SoundManager.returnRandomSound(SoundManager.s_Instance.femaleShout);
		AS.pitch = Random.Range(.95f,1.1f);
		AS.Play();
		
	}
}

public class AudioSourcePoint{
	public AudioSourcePoint(AudioClip sound, Vector3 point, float length, float volume, float pitch){
	if(sound!=null){
		GameObject audioObject = new GameObject();
		audioObject.transform.position = point;
		AudioSource AS = audioObject.AddComponent<AudioSource>();
		AS.pitch = pitch;
		AS.volume = volume;
		AS.clip = sound;
		AS.Play();
		MonoBehaviour.Destroy(audioObject,length);
		}
		

	}
}