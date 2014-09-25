using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour 
{

	private float speed; //speed the cursor moves at
	public Texture cursorTexture;
	private float cursorX;
	private float cursorY;
	private bool clicked;


	// Use this for initialization
	void Start () 
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		speed = 8.0f;
		cursorX = Screen.width/2;
		cursorY = Screen.height/2;
		clicked = false;
	}

	public bool CursorClicked()
	{
		return clicked;
	}

	public Vector2 GetCursorPosition()
	{
		return new Vector2 (cursorX, cursorY);
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateCursor ();
	}

	void OnGUI()
	{
		GUI.depth = 0;
		GUI.DrawTexture (new Rect (cursorX, cursorY, cursorTexture.width/3f, cursorTexture.height/3f), cursorTexture);
	}

	void UpdateCursor()
	{
		//cursor movement
		if (Input.GetAxis ("Cursor X") != 0) 
		{
			if(Input.GetAxis ("Cursor X") > 0)
				cursorX += speed;
			else
				cursorX -= speed;

			if(cursorX > Screen.width)
				cursorX = Screen.width;
			else if(cursorX < 0.0f)
				cursorX = 0.0f;
		}
		if (Input.GetAxis ("Cursor Y") != 0) 
		{
			if(Input.GetAxis ("Cursor Y") > 0)
				cursorY += speed;
			else
				cursorY -= speed;

			if(cursorY > Screen.height)
				cursorY = Screen.height;
			else if(cursorY < 0.0f)
				cursorY = 0.0f;
		}

		clicked = Input.GetButtonDown("CursorClick");

	}


}







