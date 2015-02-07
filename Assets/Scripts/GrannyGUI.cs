using UnityEngine;
using System.Collections;

public class GrannyGUI : VRGUI 
{
	public int sliderWidth = 60;
	public GUISkin grannySkin;
	public int speed = 0;
	public bool frenzy = false;
	public int frenzyBlinkTimer = 200;
	private float frenzyTimer = 0;

	public override void OnVRGUI()
	{
		float offset = (float)((100 - sliderWidth) * 0.5);

		GUI.skin = grannySkin;
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.Box(new Rect((Screen.width/100)*offset,(Screen.height/100)*15,(Screen.width/100)*sliderWidth,50),"");
		//Debug.Log ((Screen.width / 100) * sliderWidth);

		GUI.backgroundColor = Color.yellow;
		GUI.Box(new Rect((Screen.width/100)*offset,(Screen.height/100)*15,(Screen.width/100)*speed,50),"");

		if (frenzy) {

			Color c = new Color(Random.value, Random.value, Random.value);
			if(frenzyTimer < Time.time * 1000)
			{
				c = new Color(Random.value, Random.value, Random.value);
				frenzyTimer = Time.time * 1000 + frenzyBlinkTimer;
			}

			GUI.backgroundColor = c;

			GUI.Box (new Rect ((Screen.width / 100) * offset - 10, (Screen.height / 100) * 15 - 10, (Screen.width / 100) * sliderWidth + 20, 70), "");
		}
		GUILayout.EndArea();
	}
}
