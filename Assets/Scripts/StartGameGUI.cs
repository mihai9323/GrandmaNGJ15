using UnityEngine;
using System.Collections;

public class StartGameGUI : VRGUI 
{
	public Texture gameLogo;
	public Texture instruction;
	public GUISkin grannySkin;
	public GUISkin tintSkin;

	private bool started = false;
	
	void Start() {

	}

	public override void OnVRGUI()
	{
		
		GUI.skin = grannySkin;
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));

		string score = string.Format ("{0} {1}\n{2} {3}", "Best Combo:", World.BestCombo, "Total Score:", World.TotalScore); 
		
		if (!World.StartGame) {
			
			GUI.Box (new Rect (350, (float)((Screen.height - gameLogo.height) * 0.5), gameLogo.width, gameLogo.height), gameLogo);
			GUI.Box (new Rect (550+gameLogo.width,(float)((Screen.height - instruction.height * 0.5) * 0.5), (float)(instruction.width * 0.5), (float)(instruction.height * 0.5)), instruction);
			GUI.Box (new Rect (0,0,Screen.width,Screen.height-300), score);
		} else {


		}
		GUILayout.EndArea();
	}


}
