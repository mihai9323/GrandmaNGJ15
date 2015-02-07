using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	private static World s_Instance;
	
	public Lane[] lanes;
	
	public delegate void refreshDelegate();
	public static event refreshDelegate REFRESH;
	
	
	
	[SerializeField] private float movementSpeed;
	[SerializeField] private float generationDistance;
	
	private Vector4 bend;
	
	
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
	
	
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		StartCoroutine(Refresh());
	}
	
	private IEnumerator Refresh(){
		while(true){
			if(REFRESH!=null)REFRESH();
			
			yield return new WaitForEndOfFrame();
		}
	}
}
			