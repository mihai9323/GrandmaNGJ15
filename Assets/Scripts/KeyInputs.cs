using UnityEngine;
using System.Collections;

public class KeyInputs : MonoBehaviour {

	void Update(){
		
		if(Input.GetMouseButtonUp(0))Granny.Move(-1,10);
		if(Input.GetMouseButtonUp(1))Granny.Move(1,10);
		
	}
}
