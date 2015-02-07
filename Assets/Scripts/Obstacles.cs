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

	
}
