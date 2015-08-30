using UnityEngine;
using System.Collections;

public  abstract class Character_defaut : MonoBehaviour {
	protected Sprite head,gun;
	protected Texture red;
	protected int pulos = 1;
	protected float rate,dmg,hp;
	protected bool main,alternated,multiple;
	Rigidbody2D rigido;
	protected GameObject mainbarrel, barrel1, barrel2, maingun, gun1, gun2,bullet;

	public bool Getmain(){return main;}

	public bool Getalt(){return alternated;}

	public bool Getmult(){return multiple;}
	
	public float getrate(){return rate;}
	
	public Rigidbody2D GetRigido(){return rigido;}
	
	public GameObject GetBullet(){return bullet;}
	
	public float GetDmg(){return this.dmg;}

	public GameObject GetGun(int i)
	{
		switch(i)
		{
		case 0:
			return maingun;
			break;
		case 1:
			return gun1;
			break;
		case 2:
			return gun2;
			break;
		default:
			return null;
			break;
		}
		
	}


	// Use this for initialization
	protected void Start () 
	{
		red = Resources.Load("Images/red",typeof(Texture)) as Texture;
		rigido = GetComponent<Rigidbody2D> ();
		mainbarrel = this.transform.FindChild ("bones_parent").transform.FindChild ("gun_barrel_main").gameObject;
		barrel1 = this.transform.FindChild ("bones_h1").transform.FindChild ("gun_barrel_1").gameObject;
		barrel2 = this.transform.FindChild ("bones_h2").transform.FindChild ("gun_barrel_2").gameObject;
		maingun = this.transform.FindChild ("bones_parent").transform.FindChild ("gun_main").gameObject;
		gun1 = this.transform.FindChild ("bones_h1").gameObject;
		gun2 = this.transform.FindChild ("bones_h2").gameObject;

	}

	public  void TakeDmg(float dano)
	{
		this.hp = this.hp - dano;
		if(hp < 1)
		{
			Destroy(this.gameObject);
		}
	}

	protected void SetWeapons()
	{
		if (main == false)
		{
			gun1.GetComponent<SpriteRenderer>().sprite = gun;
			gun2.GetComponent<SpriteRenderer>().sprite = gun;
		}
		else
		{
			maingun.GetComponent<SpriteRenderer>().sprite = gun;
		}
	}



	
	
	protected void OnCollisionEnter2D(Collision2D collision) 
	{
		Vector2 finalpoint = TreatColPoints(collision.contacts);
		
		if(Mathf.Abs(finalpoint.x) > Mathf.Abs(finalpoint.y))
		{
			
		}
		else
		{
			if(finalpoint.y < 0)
			{
				this.gameObject.GetComponent<Player_Controller>().SetPulos(2);
				
				
				
			}
		}
	}
	
	
	
	protected void OnGUI()
	{
		if(this.name == "Marcos")
		{
			
			Rect r = new Rect(20,30,3*hp,30);
			GUI.DrawTexture(r,red);
			
		}
		if(this.name == "Jao")
		{
			Rect r = new Rect(Screen.width - 20-300,30,3*hp,30);
			GUI.DrawTexture(r,red);
		}
		
		
	}
	
	
	Vector2 TreatColPoints(ContactPoint2D[] pts)
	{
		float x =0;
		float y =0;
		int xc = 0;
		int yc = 0;
		foreach(ContactPoint2D point in pts)
		{
			x = x + point.point.x;
			xc ++;
			y = y + point.point.y;
			yc ++;
		}
		x = x/xc;
		y = y/yc;
		
		Vector2 finalpoint = new Vector2(x,y);
		
		Vector3 fp = new Vector3(finalpoint.x,finalpoint.y,this.transform.position.z);
		
		fp = this.transform.InverseTransformPoint(fp);
		finalpoint = new Vector2(fp.x,fp.y);
		
		return finalpoint;
	}




}
