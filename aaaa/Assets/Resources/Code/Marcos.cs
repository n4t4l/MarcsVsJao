using UnityEngine;
using System.Collections;

public class Marcos : Character_defaut 
{


	// Use this for initialization
	new void Start () 
	{
		base.Start ();
		head = Resources.Load("Images/1brela_kbca",typeof(Sprite)) as Sprite;
		gun = Resources.Load("Images/1brela_uzi",typeof(Sprite)) as Sprite;
		bullet = (GameObject)Resources.Load ("Bullet_PF");
		main = false;
		alternated = true;
		multiple = false;
		dmg = 10;
		hp = 100;
		rate = 1 / 4f;

		GetComponent<SpriteRenderer>().sprite = head;
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
		SetWeapons ();
		
	}
	

}
