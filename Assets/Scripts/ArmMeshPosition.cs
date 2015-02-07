using UnityEngine;
using System.Collections;

public class ArmMeshPosition : MonoBehaviour {

    public GameObject rForArm;
    public GameObject lForArm;
    public GameObject rHand;
    public GameObject lHand;

    public GameObject rMyoArm;
    public GameObject lMyoArm;
    public GameObject rMyoHand;
    public GameObject lMyoHand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rForArm.transform.rotation = rMyoArm.transform.rotation;
        lForArm.transform.rotation = lMyoArm.transform.rotation;
        rHand.transform.rotation = rMyoHand.transform.rotation;
        lHand.transform.rotation = lMyoHand.transform.rotation;
	}
}
