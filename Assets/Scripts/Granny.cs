using UnityEngine;
using System.Collections;

public class Granny : MonoBehaviour {
	private static Granny s_Instance;
	
	[SerializeField] private float xMovement;
	private void Awake(){
		s_Instance = this;
	}
	public static void Move(int direction, float power){
		s_Instance.transform.position += new Vector3(Mathf.Sign(direction),0,0) * s_Instance.xMovement;
		World.MovementSpeed += power;
	}
}
