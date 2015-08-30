using UnityEngine;
using System.Collections;

public class KBC2 : Player_Controller {

	// Use this for initialization
	void Start () 
	{
		base.Start ();
	}
	

	override public void SetKeys () 
	{
		keycodes[0] = KeyCode.UpArrow;
		keycodes[1] = KeyCode.LeftArrow;
		keycodes[2] = KeyCode.DownArrow;
		keycodes[3] = KeyCode.RightArrow;
		keycodes[4] = KeyCode.Keypad2;
		keycodes[5] = KeyCode.Keypad3;
	}

	void Update () 
	{
		base.Update ();
	}

	override public bool GetKeyUp(int i)
	{
		bool ok = Input.GetKeyUp (keycodes [i]);
		return ok;
	}
	
	override public bool GetKey(int i)
	{
		bool ok = Input.GetKey(keycodes[i]);
		return ok;
	}
	
	override public bool GetKeyDown(int i)
	{
		bool ok = Input.GetKeyDown(keycodes[i]);
		return ok;
	}

	
}
