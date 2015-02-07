﻿using UnityEngine;
using System.Collections;

public class Granny : MonoBehaviour {
	private static Granny s_Instance;
	
	[SerializeField] private float xMovement;
	[SerializeField] private float interpolationSpeed = 4f;
	private float y,z;
	private float timer;
	private float power;
	private int prevDirection;
	private void Awake(){
		s_Instance = this;
		timer = -1;
	}
	private void Start(){
		y = transform.position.y;
		z = transform.position.z;
	}
	public static void Move(int direction, float power){
		
		if(s_Instance.timer != -1){
			
			if(direction != s_Instance.prevDirection){
				World.MovementSpeed += power;
				
			}
			else{
				World.MovementSpeed += power;
				Vector3 targetPos = s_Instance.transform.position + new Vector3(Mathf.Sign(direction),0,0) * s_Instance.xMovement;
				if(targetPos.x < World.MinX){
					targetPos.x = World.MinX;
				}
				if(s_Instance.transform.position.x > World.MaxX){
					targetPos.x =World.MaxX;
				}
				
				s_Instance.StartCoroutine(s_Instance.move (targetPos));
			}
			s_Instance.power = 0;
			s_Instance.prevDirection = 0;
			s_Instance.timer = -1;
		}else{
			s_Instance.power = power;
			s_Instance.prevDirection = direction;
			s_Instance.timer = Time.time;
		}
		
		
		
	}
	private void Update(){
		if(Time.time>timer + .2f && timer!= -1){
			Move (prevDirection, power);
			
		}
	}
	
	
	private IEnumerator move(Vector3 position){
		Vector3 initPos = transform.position;
		float ct = 0;
		while(ct<1){
			transform.position = Vector3.Lerp(initPos,position,ct);
			ct+= Time.deltaTime * interpolationSpeed ;
			yield return new WaitForEndOfFrame();
		}
	}
}
