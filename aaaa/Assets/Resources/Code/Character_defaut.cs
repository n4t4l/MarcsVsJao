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
	float recoiltime = 0;
	GameObject bones;
	Player_Controller pc;
	int wichgun = 1;

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
				SetPulos(2);
				
				
				
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

	protected void Update () 
	{
		pc = GetComponent<Player_Controller>();

		if(recoiltime <= 0)
		{
			recoiltime = 0;
		}
		else
		{
			recoiltime = recoiltime - Time.deltaTime;
		}
		
		if(pc.GetKeyDown(4))
		{
			if(pulos>0)
			{
				  GetRigido().AddForce(Vector2.up*250,ForceMode2D.Impulse);
				pulos --;
				
			}
			
		}
		GameObject parent_bone = this.transform.FindChild ("bones_parent").gameObject;
		Vector3 rot = parent_bone.transform.rotation.eulerAngles;
		if(pc.GetKey(2))
		{
			if(pc.GetKey(1) == false && pc.GetKey(3) == false)
			{
				rot.z = 90;
			}
			else
			{
				rot.z = 45;
			}
		}
		
		if(pc.GetKey(0))
		{
			if(pc.GetKey(1) == false && pc.GetKey(3) == false)
			{
				rot.z = -90;
			}
			else
			{
				rot.z = -45;
			}
		}
		if(pc.GetKey(2) == false && pc.GetKey(0) == false)
		{
			rot.z = 0;
		}
		
		parent_bone.transform.rotation = Quaternion.Euler(rot);
		  GetGun(1).transform.rotation = Quaternion.Euler(rot);
		  GetGun(2).transform.rotation = Quaternion.Euler(rot);
		
		
		
		if(pc.GetKey(1) == false && pc.GetKey(3) == false)
		{
			
		}
		else
		{
			Quaternion rotation = this.transform.rotation;
			Vector2 oldspeed =   GetRigido().velocity;
			oldspeed.x = 0;
			if(pc.GetKey (1))
			{
				rotation.y = 0;
				oldspeed.x = oldspeed.x - 10;
				
			}
			if(pc.GetKey (3))
			{
				rotation.y = 180;
				oldspeed.x = oldspeed.x + 10;
			}
			this.transform.rotation = rotation;
			  GetRigido().velocity = oldspeed;
		}
		
		
		
		
		if(pc.GetKey(5))
		{
			if(recoiltime == 0)
			{
				Vector3 position = new Vector3();
				if(  Getmain() == true)
				{
					if(  Getmult() == true)
					{
						position =   GetGun (0).transform.position;
						GameObject Boolet;
						for(int i = 0; i < 5;i++)
						{
							Boolet = Instantiate(  GetBullet(),position,randomRotation(  GetGun (0).transform.rotation,-10,10)) as GameObject;
							Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
						}
						
					}
					else
					{
						position =   GetGun (0).transform.position;
						GameObject Boolet = Instantiate(  GetBullet(),position,  GetGun (0).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
					}
					
				}
				else
				{
					if(  Getalt() == false)
					{
						position =   GetGun (1).transform.position;
						GameObject Boolet = Instantiate(  GetBullet(),position,  GetGun (1).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
						position =   GetGun (2).transform.position;
						Boolet = Instantiate(  GetBullet(),position,  GetGun (2).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
					}
					else
					{
						position =   GetGun (wichgun).transform.position;
						GameObject Boolet = Instantiate(  GetBullet(),position,  GetGun (wichgun).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
						wichgun ++;
						if(wichgun >= 3){wichgun =1;}
					}
				}
				
				recoiltime =   getrate();
				
			}
			
			
		}
		
		
		
		
	}
	
	Quaternion  randomRotation (Quaternion original, float minimum, float maximum)
	{
		//Quaternion jae = original;
		Vector3 jae = original.eulerAngles;
		float nice = UnityEngine.Random.Range (minimum, maximum);
		jae.z = jae.z + nice;
		return Quaternion.Euler(jae);
		
		
	}
	
	public void SetPulos(int i)
	{
		pulos = i;
	}




}
