using UnityEngine;
using System.Collections;

public class Bullet_code : MonoBehaviour {

	float temp = 0;
	string owner;

	// Use this for initialization
	void Start () {


		
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = this.transform.position;

		pos = pos - this.transform.right*Time.deltaTime*25;

		this.transform.position = pos;

		temp = temp + Time.deltaTime;

		if(temp > 2)
		{
			Destroy(this.gameObject);
		}





	
	}

	public void SetOwner(string wilso)
	{
		owner = wilso;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.name != owner)
		{

			if(other.GetComponent<Player_Controller>())
			{

				other.GetComponent<Character_defaut>().TakeDmg(GameObject.Find (owner).GetComponent<Character_defaut>().GetDmg());
				Destroy(this.gameObject);

			}
			if(other.name == "Sem título")
			{
				Destroy(this.gameObject);
			}



		}

	}

}
