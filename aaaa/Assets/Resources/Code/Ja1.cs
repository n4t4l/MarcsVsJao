using UnityEngine;
using System.Collections;

public class Ja1 : Character_defaut 
{


	// Use this for initialization


	new void Start () 
	{
		base.Start ();
		head = Resources.Load("Images/jao",typeof(Sprite)) as Sprite;
		gun = Resources.Load("Images/1brela_12_sempe",typeof(Sprite)) as Sprite;
		bullet = (GameObject)Resources.Load ("Bullet_PF");
		main = true;
		alternated = true;
		multiple = true;
		dmg = 10f;
		hp = 100;
		rate = 1.5f;
		GetComponent<SpriteRenderer>().sprite = head;
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
		SetWeapons ();
		
	}


	void OnGUI()
	{
		base.OnGUI ();
		GUI.Label (new Rect (0, 500, 200, 200), GetComponent<Character_defaut> ().GetGun (0).transform.rotation.eulerAngles.ToString());
	}

}
