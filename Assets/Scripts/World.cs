using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	private static World s_Instance;
	
	public Lane[] lanes;
	
	public delegate void refreshDelegate();
	public static event refreshDelegate REFRESH;
	
	
	
	[SerializeField] private float movementSpeed;
	[SerializeField] private float generationDistance;
	
	[SerializeField]private Vector4 bend;
	[SerializeField] private float maxSpeed;
	[SerializeField] private float acceleration;
	[SerializeField] private float minX, maxX;
	[SerializeField] private float minAcc, maxAcc;
	public static float MovementSpeed{
		set{
			s_Instance.movementSpeed = value;
		}
		get{
			return s_Instance.movementSpeed;
		}
	}
	public static float GenerationDistance{
		set{
			s_Instance.generationDistance = value;
		}
		get{
			return s_Instance.generationDistance;
		}
	}
	public static Vector4 Bend{
		get{
			return s_Instance.bend;
		}
		set{
			s_Instance.bend = value;
		}
	}
	public static float MinX{
		set{
			s_Instance.minX = value;
		}
		get{
			return s_Instance.minX;
		}
	}
	public static float MaxX{
		set{
			s_Instance.maxX = value;
		}
		get{
			return s_Instance.maxX;
		}
	}
	public static float Acceleration{
		set{
			
			s_Instance.acceleration = Mathf.Clamp(value,s_Instance.minAcc,s_Instance.maxAcc);
		}
	}
	public static float MaxSpeed{
		get{
			return s_Instance.maxSpeed;
		}
	}
	
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		StartCoroutine(Refresh());
	}
	
	private IEnumerator Refresh(){
		while(true){
			if(REFRESH!=null)REFRESH();
			if(movementSpeed>0){
				movementSpeed += Time.deltaTime * acceleration;
				acceleration -= Time.deltaTime;
			}else{
				acceleration = 0;
			}
			
			movementSpeed = Mathf.Clamp(movementSpeed,0,maxSpeed);
			
			yield return new WaitForEndOfFrame();
		}
	}
}
			