using UnityEngine;
using System.Collections;

public class GrannyGUI : VRGUI 
{
	public int sliderWidth = 60;
	public GUISkin grannySkin;
	public GUISkin grannyOverlay;
	public int speed = 0;

	public override void OnVRGUI()
	{
		float offset = (float)((100 - sliderWidth) * 0.5);

		GUI.skin = grannySkin;
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.Box(new Rect((Screen.width/100)*offset,(Screen.height/100)*30,(Screen.width/100)*sliderWidth,50),"");

		GUI.skin = grannyOverlay;
		GUI.Box(new Rect((Screen.width/100)*offset,(Screen.height/100)*30,(Screen.width/100)*speed,50),"");
		GUILayout.EndArea();
	}
}
