using UnityEngine;
using System.Collections;

public class Lane : MonoBehaviour {
	
	[SerializeField] private WorldObject[] PossibleObjects;
	[SerializeField] private float minObjDistance;
	[SerializeField] private float maxObjDistance;
	[SerializeField] private int numberOfObjectsOnLane;
	[SerializeField] private bool Seamless;
	Transform lastObject;
	private void Start(){
		GenerateLane();
	}
	private void GenerateLane(){
		
		if(PossibleObjects != null && PossibleObjects.Length>0){
		
				float lastZ = 0;
			    for(int z = 0; z< numberOfObjectsOnLane; z++){
					lastZ += z * Random.Range(minObjDistance,maxObjDistance);
				    int objectIndex = Random.Range(0,PossibleObjects.Length);
				    Transform tAux = Instantiate(PossibleObjects[objectIndex].transform,
				                             new Vector3(transform.position.x,transform.position.y, lastZ),
				                             PossibleObjects[objectIndex].transform.rotation)
					as Transform;
				    if(Seamless){
					Vector3 auxP = tAux.transform.position;
					auxP.z = z * tAux.transform.localScale.z;
					tAux.transform.position = auxP; 
				    }
					tAux.transform.parent = this.transform;
					tAux.GetComponent<WorldObject>().lane = this;
				}
			}	
		}
	public void SpawnObject(WorldObject obj){
		float randomR = Random.Range(minObjDistance,maxObjDistance);
		float z = World.GenerationDistance + randomR;
		if(lastObject!=null){
			z = Mathf.Max(World.GenerationDistance + randomR,lastObject.transform.position.z + randomR);
		}
		lastObject = obj.transform;
		obj.transform.position = new Vector3(
			transform.position.x,
			transform.position.y, 
			z
			);
		if(Seamless){
			obj.transform.position = new Vector3(
				transform.position.x,
				transform.position.y, 
				lastObject.transform.position.z 
				);
		}
	}
}

