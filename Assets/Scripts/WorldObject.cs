using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	
	[HideInInspector]public Lane lane;
	
	public float chance = 1;
	
	void Start(){
		World.REFRESH += Move;
	}
	void OnDestroy(){
		World.REFRESH -= Move;
		StopAllCoroutines();
		
		Debug.Log("removed "+this.name);
	}
	void Move(){
		transform.position -= new Vector3(0,0, 1) * World.MovementSpeed * Time.deltaTime;
		if(transform.position.z<0){
			lane.SpawnObject();
			Destroy(this.gameObject);
		}
	}
	
	
	
	
}
