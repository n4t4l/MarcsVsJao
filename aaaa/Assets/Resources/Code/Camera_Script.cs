using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {
	
	GameObject p1, p2, JaoPerde, JaoPerde2;
	float ratio;
	Texture jao_perdeu;
	string lost = "";
	int ControleAparece;
	int ControleAparece2;
	void Awake()
	{
		jao_perdeu = Resources.Load("jao_perdeu",typeof(Texture)) as Texture;
	}

	// Use this for initialization
	void Start () {
		JaoPerde = Resources.Load ("JaoPerde") as GameObject;
		JaoPerde2 = Resources.Load ("JaoPerde2") as GameObject;
		p1 = GameObject.Find ("Jao");
		p2 = GameObject.Find ("Marcos");
		ratio = Screen.width/Screen.height;
	}


	
	// Update is called once per frame
	void Update () {

		if(p1 != null && p2 != null)
		{
		

		Vector3 camerapos = Vector3.Lerp(p2.transform.position,p1.transform.position,0.5f);
		camerapos.z = -1;
		this.transform.position = camerapos;

		float x = Mathf.Abs(p2.transform.position.x- p1.transform.position.x);
		float y = Mathf.Abs(p2.transform.position.y- p1.transform.position.y);

		Camera.main.orthographicSize = x/ratio/2;

		if(y > Camera.main.orthographicSize)
		{
			Camera.main.orthographicSize = y;
		}

		if(Camera.main.orthographicSize < 8)
		{
			Camera.main.orthographicSize = 8;
		}

		}
		else
		{
			if(p1 == null)
			{
				ControleAparece++;
				Vector3 camerapos = p2.transform.position;
				camerapos.z = -1;
				this.transform.position = camerapos;
				Camera.main.orthographicSize = 8;
				Rect r = new Rect(0,0,Screen.width,Screen.height);
				lost = "jao";
				

			}
			else
			{
				ControleAparece2++;
				Vector3 camerapos = p1.transform.position;
				camerapos.z = -1;
				this.transform.position = camerapos;
				Camera.main.orthographicSize = 8;
				lost = "marcs";
			}
		}

		if (ControleAparece == 1) 
		{
			Instantiate(JaoPerde, new Vector3(p2.transform.position.x, p2.transform.position.y + 3, 0), Quaternion.identity);
		}
		if (ControleAparece2 == 1) 
		{
			Instantiate(JaoPerde2, new Vector3(p1.transform.position.x, p1.transform.position.y + 3, 0), Quaternion.identity);
		}
	}


	void OnGui()
	{
		if(lost == "jao")
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),jao_perdeu);
		}
		if(lost == "marcs")
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),jao_perdeu);
			GUI.Label(new Rect(300,0,Screen.width,Screen.height),"Jao sempre perde");
		}
	}
	
}
