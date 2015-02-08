using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	private static World s_Instance;
	
	public Lane[] lanes;
	
	public delegate void refreshDelegate();
	public static event refreshDelegate REFRESH;
	
	public static int currentCombo; 
	
	[SerializeField] private float movementSpeed;
	[SerializeField] private float generationDistance;
	
	[SerializeField] private Vector4 bend;
	[SerializeField] private float maxSpeed;
	[SerializeField] private float acceleration;
	[SerializeField] private float minX, maxX;
	[SerializeField] private float minAcc, maxAcc;
	[SerializeField] private float frenzyTime;
	public static float MovementSpeed{
		set{
			if(MovementSpeed != value && value == 0){
				StartGame = false;
			}
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
			if(value != s_Instance.frenzy && value){
				s_Instance.StartCoroutine(s_Instance.ChangeSound(s_Instance.themeMusic,s_Instance.frenzyMusic));
				MovementSpeed = MaxSpeed;
				
				
			}else if(value!=s_Instance.frenzy && !value){
				s_Instance.StartCoroutine(s_Instance.ChangeSound(s_Instance.frenzyMusic,s_Instance.themeMusic));
			}
			s_Instance.frenzy = value;
			if(value)s_Instance.frenzyTimer = Time.time;
		}
		get{
			return s_Instance.frenzy;
		} 
		
	}
	private float bornPlayedTime =0 ;
	public static bool StartGame{
		set{
			if(value != s_Instance.startGame && value){
				new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.looseNana),Granny._transform.position+ Vector3.back * 1.0f,4.0f,1.0f,1.0f);
				if(Time.time>s_Instance.bornPlayedTime + 30){
					s_Instance.bornToBeWild.Play();
					s_Instance.bornPlayedTime = Time.time;
					}
				s_Instance.StartCoroutine(s_Instance.ChangeSound(s_Instance.introMusic,s_Instance.themeMusic));
				
			}
			s_Instance.startGame = value;
		}
		get{
			return s_Instance.startGame;
		}
	}
	public static int BestCombo{
		set{
			if(value>=BestCombo){
				s_Instance.bestCombo = value;
			}
			
		}
		get{
			return s_Instance.bestCombo;
		}
	}
	public static int TotalScore{
		set{
			s_Instance.totalScore = value;
		}
		get{
			return s_Instance.totalScore;
		}
	}
	
	public AudioSource introMusic;
	public AudioSource themeMusic;

	public AudioSource frenzyMusic;
	//public AudioSource frenzyMusicLoop;
	public AudioSource bornToBeWild;
	public AudioSource angryDoctor;
	private int totalScore;
	private int bestCombo;
	
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
	private IEnumerator ChangeSound(AudioSource oldSource, AudioSource newSource){
		float c = 0;

		newSource.volume = 1;
		if(newSource!=themeMusic || !newSource.isPlaying) newSource.Play();

		
		
		while (c<1) {
			c+= Time.deltaTime * .5f;
			oldSource.volume = Mathf.Lerp(oldSource.volume,0F,c);
			yield return new WaitForEndOfFrame();
		}
		oldSource.volume = 0;
	}

	private IEnumerator Refresh(){
		while(true){
			if(REFRESH!=null)REFRESH();
			if(movementSpeed>0){
				if(movementSpeed > World.MaxSpeed * 0.26f && !startGame)
					StartGame = true;
				movementSpeed += Time.deltaTime * acceleration;
				if(!Frenzy){
					Acceleration -= Time.deltaTime;
					
					}else{
					Acceleration = maxAcc;
					}
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
	float timeWait =0;
	
	private void Update(){
		if(!startGame){
			if(Time.time > timeWait + 15 + Random.Range(0,2)){
				timeWait = Time.time;
				new AudioSourcePoint(SoundManager.returnRandomSound(SoundManager.s_Instance.slowNana),Granny._transform.position+ Vector3.back * 1.0f,4.0f,1.0f,1.0f);
			}
		}
		
	}
}
			