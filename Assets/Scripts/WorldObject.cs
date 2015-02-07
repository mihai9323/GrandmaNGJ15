using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	
	public Lane lane;
	void Start(){
		World.REFRESH += Move;
	}
	void OnDestroy(){
		World.REFRESH -= Move;
	}
	void Move(){
		transform.position -= new Vector3(0,0, 1) * World.MovementSpeed * Time.deltaTime;
		if(transform.position.z<0){
			lane.SpawnObject(this);
		}
		Bend ();
	}
	void Bend(){
		renderer.material.SetVector("_QOffset", World.Bend);
	}
	
	
}
