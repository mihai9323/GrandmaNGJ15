using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {

    public enum ObstacleType {
        doctor,
        nurse,
        tables,
        beds
        
    }

    //private ObstacleType _type;
    public ObstacleType type; 
//{

//        get {
//            return _type;
//        }
//        set {
//            _type = value;
//        }
//    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        switch (type) {
            case ObstacleType.doctor:
                HumanBehaviour();
                break;
            case ObstacleType.nurse:
                HumanBehaviour();
                break;
            case ObstacleType.tables:
                break;
            case ObstacleType.beds:
                break;
            default:
                break;
        }
	
	}

    void HumanBehaviour() {

    }

    void StationaryBehaviour() {

    }

    public void SetObstacleType(int typeWeight) {
        Debug.Log("TypeWeight " + typeWeight);
        if (typeWeight <= 25) {
            type = ObstacleType.doctor;
            renderer.material.color = Color.red;
        }
        else if (typeWeight > 25 && typeWeight <= 50) {
            type = ObstacleType.nurse;
            renderer.material.color = Color.blue;
        }
        else if (typeWeight > 50 && typeWeight <= 75) {
            type = ObstacleType.beds;
            renderer.material.color = Color.green;
        }
        else if (typeWeight > 75 && typeWeight <= 100) {
            type = ObstacleType.tables;
            renderer.material.color = Color.yellow;
        }
    }
}
