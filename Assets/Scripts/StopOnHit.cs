using UnityEngine;
using System.Collections;

public class StopOnHit : MonoBehaviour {

	private void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Table"){
			if(!World.Frenzy)World.MovementSpeed = 0;
			else World.MovementSpeed /=2;
			GameObject gob = col.collider.gameObject;
			gob.rigidbody.isKinematic = false;
			
			gob.rigidbody.AddForce(Vector3.forward * 2000,ForceMode.Force);
			Destroy(gob,2.0f);
			gob.GetComponent<WorldObject>().lane.SpawnObject();
			new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.tableSounds),transform.position, 3.0f, 1.0f, Random.Range(.9f,1.5f));
			AudioSource AS = gob.AddComponent<AudioSource>();
			if(World.MovementSpeed > 3/4 * World.MaxSpeed)AS.clip = SoundManager.returnRandomSound(SoundManager.s_Instance.nanaSounds);
			AS.pitch = Random.Range(.95f,1.1f);
			AS.Play();
		}
	}
}
