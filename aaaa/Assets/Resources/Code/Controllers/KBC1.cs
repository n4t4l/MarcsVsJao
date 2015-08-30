using UnityEngine;
using System.Collections;

public class KBC1 : Player_Controller {
		

	override public void SetKeys () {

		keycodes[0] = KeyCode.W;//w
		keycodes[1] = KeyCode.A;//a
		keycodes[2] = KeyCode.S;//s
		keycodes[3] = KeyCode.D;//d
		keycodes[4] = KeyCode.T;//t
		keycodes[5] = KeyCode.Y;;//y

	
	}

	 override public bool GetKeyUp(int i)
	{
		return Input.GetKeyUp(keycodes[i]);
	}

	override public bool GetKey(int i)
	{
		return Input.GetKey(keycodes[i]);
	}

	override public bool GetKeyDown(int i)
	{
		return Input.GetKeyDown(keycodes[i]);
	}



}
