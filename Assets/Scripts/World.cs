using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	private static World s_Instance;
	
	public Lane[] lanes;
	
	
	
	
	
	[SerializeField] private float movementSpeed;
	[SerializeField] private float generationDistance;
	
	
	
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
	
	
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		
	}
	
	
}
			