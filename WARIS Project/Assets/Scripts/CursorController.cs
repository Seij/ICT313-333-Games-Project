﻿using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour 
{

	private float speed; //speed the cursor moves at
	public Texture cursorTexture;
	private float cursorX;
	private float cursorY;
	private bool clicked;
	private float texWidth;
	private float texHeight;


	// Use this for initialization
	void Start () 
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		speed = 8.0f;
		cursorX = Screen.width/4;
		cursorY = Screen.height/4;
		clicked = false;
		texWidth = cursorTexture.width / 3f;
		texHeight = cursorTexture.height / 3f;
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
		GUI.DrawTexture (new Rect (cursorX, cursorY, texWidth, texHeight), cursorTexture);
		GUI.DrawTexture (new Rect (cursorX+Screen.width/2, cursorY, texWidth, texHeight), cursorTexture); //draws a duplicate cursor on the other half of screen
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

			//restricts cursor X position to its half of the screen
			if(cursorX > Screen.width/2 - texWidth)
				cursorX = Screen.width/2 - texWidth;
			else if(cursorX < 0.0f)
				cursorX = 0.0f;
		}
		if (Input.GetAxis ("Cursor Y") != 0) 
		{
			if(Input.GetAxis ("Cursor Y") > 0)
				cursorY += speed;
			else
				cursorY -= speed;

			//restricts cursor Y position to height of the screen
			if(cursorY > Screen.height - texHeight)
				cursorY = Screen.height - texHeight;
			else if(cursorY < 0.0f)
				cursorY = 0.0f;
		}

		clicked = Input.GetButtonDown("CursorClick");

	}


}







