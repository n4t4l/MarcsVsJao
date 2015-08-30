using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Player_Controller : MonoBehaviour {


	float angle;
	Sprite newsprite;
	Texture red;
	GameObject parent_bone;
	protected KeyCode[] keycodes = new KeyCode[6];
	Character_defaut cd;






	
	// Use this for initialization
	protected void Start () {


		cd = this.GetComponent<Character_defaut> ();
		SetKeys();



	}

	abstract public void SetKeys ();
	abstract public bool GetKeyUp (int i);
	abstract public bool GetKeyDown (int i);
	abstract public bool GetKey (int i);
	
	// Update is called once per frame





}
