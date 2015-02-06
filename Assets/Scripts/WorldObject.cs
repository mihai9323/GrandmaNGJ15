using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	
	void FixedUpdate(){
		transform.position -= new Vector3(0,0, 1) * World.MovementSpeed * Time.fixedDeltaTime;
		if(transform.position.z<0){
			World.SpawnObject(this.transform);
		}
	}
	
	
}
