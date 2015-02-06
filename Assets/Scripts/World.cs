using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	private static World s_Instance;
	
	[SerializeField] private Transform[]  WorldObjects;
	[SerializeField] private int numberOfLanes;
	[SerializeField] private float laneWidth;
	[SerializeField] private float minObjDistance;
	[SerializeField] private float maxObjDistance;
	[SerializeField] private int numberOfObjects;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float generationDistance;
	
	
	public static float MovementSpeed{
		set{
			s_Instance.movementSpeed = value;
		}
		get{
			return s_Instance.movementSpeed;
		}
	}
	
	
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		GenerateWorld();
	}
	private void GenerateWorld(){
	
		if(WorldObjects != null && WorldObjects.Length>0){
			for(int x = -(int)((float)numberOfLanes/2); x<= (int)((float)numberOfLanes)/2; x ++){
				    float lastZ = 0;
			     	for(int z = 0; z< numberOfObjects; z++){
					    lastZ += z * Random.Range(minObjDistance,maxObjDistance);
					    int objectIndex = Random.Range(0,WorldObjects.Length);
					    Transform tAux = Instantiate(WorldObjects[objectIndex],
					                                 new Vector3((float)x * laneWidth,0, lastZ),
					                                 WorldObjects[objectIndex].transform.rotation)
					                      as Transform;
					    
			     	}
		    }	
	    }
	}
	public static void SpawnObject(Transform obj){
		obj.transform.position = new Vector3(
			                        (float)Random.Range(-(int)((float)s_Instance.numberOfLanes/2), (int)((float)s_Instance.numberOfLanes)/2 +1) * s_Instance.laneWidth,
			                        0, 
			                        s_Instance.generationDistance);
	}
}
