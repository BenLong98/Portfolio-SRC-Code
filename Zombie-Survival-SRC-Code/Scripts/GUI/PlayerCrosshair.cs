using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour {

	public Texture2D crosshair;

	void OnGUI(){
		float xMouse = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshair.width / 2);
		float yMouse = (Screen.height - Input.mousePosition.y) - (crosshair.height / 2);

		GUI.DrawTexture (new Rect (xMouse, yMouse, crosshair.width, crosshair.height), crosshair);

		Cursor.visible = false;

	}
}
