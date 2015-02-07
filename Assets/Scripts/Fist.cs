﻿using UnityEngine;
using System.Collections;


public class Fist : MonoBehaviour {

	private void OnCollisionEnter(Collision col){
		switch(col.collider.tag){
			case "Pill": CollectPill(col.collider.gameObject); break;
		    case "Doctor": DoctorPunch(col.collider.gameObject,col.contacts[0].point); break;
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
		gob.rigidbody.isKinematic = false;
		gob.rigidbody.AddForce(Vector3.forward * 2000,ForceMode.Force);
		Destroy(gob,2.0f);
		gob.GetComponent<WorldObject>().lane.SpawnObject();
		new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.punchSounds),transform.position, 3.0f, 1.0f, Random.Range(.9f,1.5f));
		Debug.Log("doctor hit");
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