using UnityEngine;
using System.Collections;

public class GrannyGUI : VRGUI 
{
	public Texture background;
	public Texture slider;

	public override void OnVRGUI()
	{
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

		GUI.Box(new Rect((Screen.width/100)*20,(Screen.height/100)*30,(Screen.width/100)*60,50),"");
		GUILayout.EndArea();
	}
}
