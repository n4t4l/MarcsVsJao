using UnityEngine;
using System.Collections;

public class JTC : Player_Controller {
	float FAKEX;
	float FAKEY;
	float LASTFAKEX;
	float LASTFAKEY;
	float deadzone;
	override public void SetKeys () {
		
		/*keycodes[0] = KeyCode.W;//w
		keycodes[1] = KeyCode.A;//a
		keycodes[2] = KeyCode.S;//s
		keycodes[3] = KeyCode.D;//d*/
		keycodes[4] = KeyCode.T;//t
		keycodes[5] = KeyCode.Y;;//y
		
		
	}
	
	override public bool GetKeyUp(int i)
	{
		if(i >= 4)
		{
			bool ok = Input.GetKeyUp (keycodes [i]);
			return ok;
		}
		else
		{
			if(i == 0 || i == 2)
			{
				//eixo x
				if(i == 0)
				{
					if(LASTFAKEX < (0-deadzone))
					{
						if(FAKEX >=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					if(LASTFAKEX > (0-deadzone))
					{
						if(FAKEX <=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				
			}
			else
			{
				//eixo y
				if(i == 1)
				{
					if(LASTFAKEY < (0-deadzone))
					{
						if(FAKEY >=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					if(LASTFAKEY > (0-deadzone))
					{
						if(FAKEY <=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				
			}
		}

	}

	/*

	*/
	override public bool GetKey(int i)
	{
		if(i >= 4)
		{
			bool ok = Input.GetKeyUp (keycodes [i]);
			return ok;
		}
		else
		{
			if(i == 0 || i == 2)
			{
				//eixo x
				if(i == 0)
				{
					if(FAKEX < (0-deadzone))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					if(FAKEX > (0+deadzone))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				
			}
			else
			{
				//eixo y
				if(i == 1)
				{
					if(FAKEY < (0-deadzone))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					if(FAKEY > (0+deadzone))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				
			}
		}
	}
	
	override public bool GetKeyDown(int i)
	{
		if(i >= 4)
		{
			bool ok = Input.GetKeyDown (keycodes [i]);
			return ok;
		}
		else
		{
			if(i == 0 || i == 2)
			{
				//eixo x
				if(i == 0)
				{
					if(LASTFAKEX > (0-deadzone))
					{
						if(FAKEX <=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					if(LASTFAKEX < (0-deadzone))
					{
						if(FAKEX >=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				
			}
			else
			{
				//eixo y
				if(i == 1)
				{
					if(LASTFAKEY > (0-deadzone))
					{
						if(FAKEY <=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					if(LASTFAKEY < (0-deadzone))
					{
						if(FAKEY >=(0-deadzone))
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				
			}
		}
	}

	new void LateUpdate()
	{
		
				LASTFAKEX = FAKEX;
				LASTFAKEY = FAKEY;
		
	}
}
