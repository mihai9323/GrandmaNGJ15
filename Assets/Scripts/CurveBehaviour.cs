using UnityEngine;
using System.Collections;

public class CurveBehaviour : MonoBehaviour {

    Vector4 targetVectorOffset;
    Vector4 currentVectorOffset;
    float startTime;
    float vectorDist;
    float speed = 2f;
    bool updateOffset = true;
    float offsetRangeMax = 30;
    float offsetRangeMin = -30;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(ChangeOffset(Random.Range(5, 10)));

            lerpCurveOffset();

        //Debug.Log("UpdateBool " + updateOffset);
	}

    void lerpCurveOffset() {

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / vectorDist;
        Vector4 temPos = Vector4.Lerp(currentVectorOffset, targetVectorOffset, fracJourney);

        renderer.material.SetVector("_QOffset", temPos);
        
        //Debug.Log("CurrentOffset " + currentVectorOffset);
        //Debug.Log("TargetOffset " + targetVectorOffset);
        //Debug.Log("tempOffset " + temPos);
    }

    IEnumerator ChangeOffset(float updateFrequence) {

        yield return new WaitForSeconds(updateFrequence);

        //Debug.Log("IM IN COROUTINE!!");
        currentVectorOffset = renderer.material.GetVector("_QOffset");
        startTime = Time.time;
        vectorDist = Vector4.Distance(currentVectorOffset, targetVectorOffset);


        targetVectorOffset = new Vector4(Random.Range(offsetRangeMin, offsetRangeMax), Random.Range(offsetRangeMin, offsetRangeMax), Random.Range(offsetRangeMin, offsetRangeMax), 0);

    }
}
