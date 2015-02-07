using UnityEngine;
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
		StartCoroutine(gob.GetComponent<WorldObject>().SpawnMe(2.0f));
	}
	private void DoctorPunch(GameObject gob, Vector3 point){
		gob.AddComponent<Rigidbody>().AddExplosionForce(20,point,10);
		StartCoroutine(gob.GetComponent<WorldObject>().SpawnMe(2.0f));
	}
}
