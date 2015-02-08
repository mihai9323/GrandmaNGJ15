using UnityEngine;
using System.Collections;

public class Bend : MonoBehaviour {

	void Start(){
		World.REFRESH += bend;
	}
	void OnDestroy(){
		World.REFRESH -= bend;
		
		
	}
	
	void bend(){
	foreach(Material mat in renderer.materials)
		mat.SetVector("_QOffset", World.Bend);
	}
}
