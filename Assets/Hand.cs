using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	int RollState = 0;
    float RollStartTime;
	float RollForce = 0;

	// Use this for initialization
	void Start () {
		
        RollStartTime = Time.time;
	}

	void OnTriggerEnter(Collider other)
	{
		
		//Debug.Log (other.gameObject.name);
		if(other.gameObject.name == "LowerRollDetect")
		{
			RollState = 1;
			RollStartTime = Time.time; 

		}
		if(other.gameObject.name == "UpperRollDetect")
		{
			if (RollState == 1) 
			{
				RollState=0;
				float rollTime = Time.time - RollStartTime;
				
				RollForce = 1/(0.01f+rollTime);
				
				if (this.gameObject.name == "LeftHand")
				{
					Granny.Move(1,RollForce);
				}
				if (this.gameObject.name == "RightHand")
				{
					Granny.Move(-1,RollForce);				
				}
			}
		}

		bool isHandUp = other.gameObject.name == "HandsUpDetect";
		{
			if (this.gameObject.name == "LeftHand")
			{
				Granny.HandsUp(1,isHandUp);
			}
			if (this.gameObject.name == "RightHand")
			{
				Granny.HandsUp(-1,isHandUp);				
			}
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
