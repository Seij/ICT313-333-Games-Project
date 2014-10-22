using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ResourceController : MonoBehaviour 
{
	public BuildingManager mBuildingManager;
	
	void Start()
	{
		mBuildingManager = new BuildingManager ();

		LoadBuildingData ();
		LoadStaffData ();
		LoadLectureData ();
	}

	void Update ()
	{

	}

	void LoadBuildingData()
	{
		//Load building data here
	}

	void LoadStaffData()
	{
		//Load staff data here
	}

	void LoadLectureData()
	{
		//Load lecture data here
	}
}