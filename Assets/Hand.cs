using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	int RollState = 0;
	float RollStartTime = Time.time;
	float RollForce = 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Hit something");
		//Debug.Log (other.gameObject.name);
		if(other.gameObject.name == "LowerRollDetect")
		{
			RollState = 1;
			RollStartTime = Time.time; 
			//Debug.Log ("lower");
		}
		if(other.gameObject.name == "UpperRollDetect")
		{
			if (RollState == 1) 
			{
				RollState=0;
				float rollTime = Time.time - RollStartTime;
				//Debug.Log("rollTime:"+rollTime);
				RollForce = 1/(0.01f+rollTime);
				Debug.Log(this.gameObject.name+" RollForce:"+RollForce);
				if (this.gameObject.name == "LeftHand")
				{
					Granny.Move(-1,RollForce);
				}
				if (this.gameObject.name == "RightHand")
				{
					Granny.Move(1,RollForce);
					//wheelForce(
				}
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
