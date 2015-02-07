using UnityEngine;
using System.Collections;

public class CurveBehaviour : MonoBehaviour {

    Vector4 targetVectorOffset;
    Vector4 currentVectorOffset;
    float startTime;
    float vectorDist;
    
    bool updateOffset = true;
    float offsetRangeMax = 30;
    float offsetRangeMin = -30;

	// Use this for initialization
	void Start () {
		currentVectorOffset = World.Bend;
		StartCoroutine(ChangeOffset());
		
	}
	
	// Update is called once per frame
	void Update () {


            lerpCurveOffset();

        //Debug.Log("UpdateBool " + updateOffset);
	}

    void lerpCurveOffset() {

        float distCovered = (Time.time - startTime) * World.MovementSpeed;
        float fracJourney = distCovered / vectorDist;
        Vector4 temPos = Vector4.Lerp(currentVectorOffset, targetVectorOffset, fracJourney);
        World.Bend = temPos;
       
        
        //Debug.Log("CurrentOffset " + currentVectorOffset);
        //Debug.Log("TargetOffset " + targetVectorOffset);
        //Debug.Log("tempOffset " + temPos);
    }

    IEnumerator ChangeOffset() {
		while(true){

			//Debug.Log("IM IN COROUTINE!!");
			currentVectorOffset = World.Bend;
	        startTime = Time.time;
			targetVectorOffset = new Vector4(Random.Range(offsetRangeMin, offsetRangeMax), Random.Range(offsetRangeMin, offsetRangeMax), Random.Range(offsetRangeMin, offsetRangeMax), 0);
	        vectorDist = Vector4.Distance(currentVectorOffset, targetVectorOffset);
	
	
			yield return new WaitForSeconds(Random.Range(5,10));
		}

    }
}
