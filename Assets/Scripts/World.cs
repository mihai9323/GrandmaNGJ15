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
	[SerializeField] private float frenzyTime;
	public static float MovementSpeed{
		set{
			value = Mathf.Clamp(value,0,MaxSpeed);
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
		get{
			
			return s_Instance.acceleration;
		}
	}
	public static float MaxSpeed{
		get{
			return s_Instance.maxSpeed;
		}
	}
	public static bool Frenzy{
		set{
			s_Instance.frenzy = value;
			if(value)s_Instance.frenzyTimer = Time.time;
		}
		get{
			return s_Instance.frenzy;
		}
	}

	public static bool StartGame{
		set{
			if(value != s_Instance.startGame && value){
				s_Instance.StartCoroutine(s_Instance.ChangeSound());
			}
			s_Instance.startGame = value;
		}
		get{
			return s_Instance.startGame;
		}
	}
	public AudioSource introMusic;
	public AudioSource themeMusic;
	public AudioSource angryDoctor;
	private bool frenzy;
	private float frenzyTimer;

	private bool startGame = false;
	
	private void Awake(){
		s_Instance = this;
	}
	private void Start(){
		StartCoroutine(Refresh());
		introMusic.Play ();
	}
	private IEnumerator ChangeSound(){
		float c = 0;
		themeMusic.Play();
		angryDoctor.Play ();
		while (c<1) {
			c+= Time.deltaTime * .2f;
			introMusic.volume = Mathf.Lerp(introMusic.volume,0F,c);
			yield return new WaitForEndOfFrame();
		}
		introMusic.volume = 0;
	}

	private IEnumerator Refresh(){
		while(true){
			if(REFRESH!=null)REFRESH();
			if(movementSpeed>0){
				if(movementSpeed > World.MaxSpeed * 0.26f && !startGame)
					StartGame = true;
				movementSpeed += Time.deltaTime * acceleration;
				Acceleration -= Time.deltaTime;
			}else{
				Acceleration = 0;
			}
			if(Time.time>frenzyTimer+ frenzyTime){
				Frenzy = false;
			}
			movementSpeed = Mathf.Clamp(movementSpeed,0,maxSpeed);
			
			yield return new WaitForEndOfFrame();
		}
	}
}
			