using UnityEngine;
using System.Collections;

public class ArmMeshPosition : MonoBehaviour {

    public GameObject rForShoulder;
    public GameObject lForShoulder;
    public GameObject rHand;
    public GameObject lHand;

    public GameObject rMyoShoulder;
    public GameObject lMyoShoulder;
    public GameObject rMyoHand;
    public GameObject lMyoHand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       // rForShoulder.transform.rotation = rMyoShoulder.transform.rotation;
        //lForShoulder.transform.rotation = lMyoShoulder.transform.rotation;
        //lForShoulder.transform.localEulerAngles = lForShoulder.transform.localEulerAngles - (lForShoulder.transform.localEulerAngles - lMyoShoulder.transform.localEulerAngles);

        //rHand.transform.rotation = rMyoHand.transform.rotation;
       
        //lHand.transform.rotation = lMyoHand.transform.rotation;
        //lHand.transform.localEulerAngles = lHand.transform.localEulerAngles - (lHand.transform.localEulerAngles - lMyoHand.transform.localEulerAngles);
	}
}
