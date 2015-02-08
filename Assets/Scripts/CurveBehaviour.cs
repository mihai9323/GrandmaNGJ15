using UnityEngine;
using System.Collections;

public class CurveBehaviour : MonoBehaviour {

    Vector4 targetVectorOffset;
    Vector4 currentVectorOffset;
    float startTime;
    float vectorDist;
    
    bool updateOffset = true;
    float distCovered = 0;
	[SerializeField]float angle;
	[SerializeField] float radius;
	[SerializeField] float Z;
	// Use this for initialization
	void Start () {
		currentVectorOffset = World.Bend;
		angle = Random.Range(0,360);
		StartCoroutine(ChangeOffset());
		
	}
	
	// Update is called once per frame
	void Update () {


            lerpCurveOffset();

        //Debug.Log("UpdateBool " + updateOffset);
	}

    void lerpCurveOffset() {

        distCovered += Time.deltaTime * World.MovementSpeed;
        float fracJourney = distCovered / vectorDist;
        Vector4 temPos = Vector4.Lerp(currentVectorOffset, targetVectorOffset, fracJourney);
        World.Bend = temPos;
       
        
        //Debug.Log("CurrentOffset " + currentVectorOffset);
        //Debug.Log("TargetOffset " + targetVectorOffset);
        //Debug.Log("tempOffset " + temPos);
    }

    IEnumerator ChangeOffset() {
		while(true){
			distCovered = 0;
			//Debug.Log("IM IN COROUTINE!!");
			currentVectorOffset = World.Bend;
	        startTime = Time.time;
			//targetVectorOffset = new Vector4(Random.Range(offsetRangeMin, offsetRangeMax), Random.Range(offsetRangeMin, offsetRangeMax), Random.Range(offsetRangeMin, offsetRangeMax), 0);
			angle += Random.Range(-15,15);
			
			targetVectorOffset = new Vector4(Mathf.Cos(angle/360 * Mathf.PI) * radius ,Mathf.Sin(angle/360 * Mathf.PI) * radius, Z, 0);
			vectorDist = Vector4.Distance(currentVectorOffset, targetVectorOffset);
	
			
			yield return new WaitForSeconds(Random.Range(6,15));
			
		}

    }
}
