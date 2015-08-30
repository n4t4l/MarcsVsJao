using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Player_Controller : MonoBehaviour {

	int wichgun = 1;
	int pulos = 1;
	float angle;
	Sprite newsprite;
	Texture red;
	GameObject parent_bone;
	protected KeyCode[] keycodes = new KeyCode[6];
	Character_defaut cd;

	float recoiltime = 0;
	GameObject bones;
	float hp = 100;
	float dmg = 10;




	
	// Use this for initialization
	protected void Start () {


		cd = this.GetComponent<Character_defaut> ();
		SetKeys();
		switch(this.name)
		{
			case "Marcos":




			break;
			case "Jao":


			newsprite =  Resources.Load ("Images/jao", typeof(Sprite))   as Sprite ;
			GetComponent<SpriteRenderer>().sprite = newsprite;
			Destroy(GetComponent<PolygonCollider2D>());
			gameObject.AddComponent<PolygonCollider2D>();
			break;
		}


	}

	abstract public void SetKeys ();
	abstract public bool GetKeyUp (int i);
	abstract public bool GetKeyDown (int i);
	abstract public bool GetKey (int i);
	
	// Update is called once per frame
	protected void Update () 
	{

		if(recoiltime <= 0)
		{
			recoiltime = 0;
		}
		else
		{
			recoiltime = recoiltime - Time.deltaTime;
		}

		if(GetKeyDown(4))
		{
			if(pulos>0)
			{
				cd.GetRigido().AddForce(Vector2.up*250,ForceMode2D.Impulse);
				pulos --;

			}

		}
		GameObject parent_bone = this.transform.FindChild ("bones_parent").gameObject;
		Vector3 rot = parent_bone.transform.rotation.eulerAngles;
		if(GetKey(2))
		{
			if(GetKey(1) == false && GetKey(3) == false)
			{
				rot.z = 90;
			}
			else
			{
				rot.z = 45;
			}
		}

		if(GetKey(0))
		{
			if(GetKey(1) == false && GetKey(3) == false)
			{
				rot.z = -90;
			}
			else
			{
				rot.z = -45;
			}
		}
		if(GetKey(2) == false && GetKey(0) == false)
		{
			rot.z = 0;
		}

		parent_bone.transform.rotation = Quaternion.Euler(rot);
		cd.GetGun(1).transform.rotation = Quaternion.Euler(rot);
		cd.GetGun(2).transform.rotation = Quaternion.Euler(rot);



		if(GetKey(1) == false && GetKey(3) == false)
		{

		}
		else
		{
			Quaternion rotation = this.transform.rotation;
			Vector2 oldspeed = cd.GetRigido().velocity;
			oldspeed.x = 0;
			if(GetKey (1))
			{
				rotation.y = 0;
				oldspeed.x = oldspeed.x - 10;

			}
			if(GetKey (3))
			{
				rotation.y = 180;
				oldspeed.x = oldspeed.x + 10;
			}
			this.transform.rotation = rotation;
			cd.GetRigido().velocity = oldspeed;
		}


		

		if(GetKey(5))
		{
			if(recoiltime == 0)
			{
				Vector3 position = new Vector3();
				if(cd.Getmain() == true)
				{
					if(cd.Getmult() == true)
					{
						position = cd.GetGun (0).transform.position;
						GameObject Boolet;
						for(int i = 0; i < 5;i++)
						{
							Boolet = Instantiate(cd.GetBullet(),position,randomRotation(cd.GetGun (0).transform.rotation,-10,10)) as GameObject;
							Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
						}

					}
					else
					{
						position = cd.GetGun (0).transform.position;
						GameObject Boolet = Instantiate(cd.GetBullet(),position,cd.GetGun (0).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
					}

				}
				else
				{
					if(cd.Getalt() == false)
					{
						position = cd.GetGun (1).transform.position;
						GameObject Boolet = Instantiate(cd.GetBullet(),position,cd.GetGun (1).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
						position = cd.GetGun (2).transform.position;
						Boolet = Instantiate(cd.GetBullet(),position,cd.GetGun (2).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
					}
					else
					{
						position = cd.GetGun (wichgun).transform.position;
						GameObject Boolet = Instantiate(cd.GetBullet(),position,cd.GetGun (wichgun).transform.rotation) as GameObject;
						Boolet.GetComponent<Bullet_code>().SetOwner(this.name);
						wichgun ++;
						if(wichgun >= 3){wichgun =1;}
					}
				}

				recoiltime = cd.getrate();

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
