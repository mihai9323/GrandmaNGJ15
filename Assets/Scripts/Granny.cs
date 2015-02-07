using UnityEngine;
using System.Collections;

public class Granny : MonoBehaviour {
	private static Granny s_Instance;
	
	[SerializeField] private float xMovement;
	
	private float y,z;
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		y = transform.position.y;
		z = transform.position.z;
	}
	public static void Move(int direction, float power){
		
		Vector3 targetPos = s_Instance.transform.position + new Vector3(Mathf.Sign(direction),0,0) * s_Instance.xMovement;
		if(targetPos.x < World.MinX){
			targetPos.x = World.MinX;
		}
		if(s_Instance.transform.position.x > World.MaxX){
			targetPos.x =World.MaxX;
		}
		
		s_Instance.StartCoroutine(s_Instance.move (targetPos));
		World.MovementSpeed += power;
		
	}
	
	private IEnumerator move(Vector3 position){
		Vector3 initPos = transform.position;
		float ct = 0;
		while(ct<1){
			transform.position = Vector3.Lerp(initPos,position,ct);
			ct+= Time.deltaTime * World.MovementSpeed;
			yield return new WaitForEndOfFrame();
		}
	}
}
