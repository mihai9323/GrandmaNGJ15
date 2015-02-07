using UnityEngine;
using System.Collections;

public class StartGameGUI : VRGUI 
{
	public Texture gameLogo;
	public Texture instruction;
	public GUISkin grannySkin;

	private bool started = false;
	
	void Start() {

	}

	public override void OnVRGUI()
	{
		
		GUI.skin = grannySkin;
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
		
		if (!World.StartGame) {
			Debug.Log ("game started");
			GUI.Box (new Rect ((float)((Screen.width - gameLogo.width) * 0.5), 0, gameLogo.width, gameLogo.height), gameLogo);
			GUI.Box (new Rect ((float)((Screen.width - instruction.width * 0.5) * 0.5), 0, (float)(instruction.width * 0.5), (float)(instruction.height * 0.5)), instruction);
		} else {


		}
		GUILayout.EndArea();
	}


}
