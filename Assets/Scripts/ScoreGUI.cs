using UnityEngine;
using System.Collections;

public class ScoreGUI : VRGUI 
{
	public GUISkin grannySkin;
	
	private bool started = false;
	
	void Start() {
		
	}
	
	public override void OnVRGUI()
	{
		GUI.skin = grannySkin;
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));

		string score = string.Format ("{0} {1}\n{2} {3}", "Best Combo:", World.BestCombo, "Total Score:", World.TotalScore); 

		
		if (World.MovementSpeed == 0.0f && World.StartGame) {
			GUI.Box (new Rect (0,0,Screen.width,Screen.height), score);

		} else {
			
			
		}
		GUILayout.EndArea();
	}
	
	
}