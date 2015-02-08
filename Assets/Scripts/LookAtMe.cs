using UnityEngine;
using System.Collections;

public class LookAtMe : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Granny._transform.position);
		Vector3 myEuler = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(myEuler);
	}
}
