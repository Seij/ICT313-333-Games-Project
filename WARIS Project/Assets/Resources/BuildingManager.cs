using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager
{  
	private List<Building> mBuildings; 
	
	public BuildingManager()
	{
		mBuildings = new List<Building> ();
	}
	
	public Building GetBuildingAt(int index)
	{
		return mBuildings [index];
	}

	public bool AddBuilding(Building b)
	{
		bool added;
		int startSize = mBuildings.Count;
		Building temp = new Building (b);

		if(!this.ContainsBuilding(b))
			mBuildings.Add(temp);
			
		if(mBuildings.Count > startSize)
			added = true;
		else
			added =false;

		return added;
	}
	
	public bool RemoveBuilding(Building b)
	{
		bool removed;
		int startSize = mBuildings.Count;
		
		for (int i=0; i<mBuildings.Count; i++) 
		{
			if(mBuildings[i].GetNumber().Equals(b.GetNumber()))
			{
				mBuildings.RemoveAt(i);
				break;
			}
		}

		if(mBuildings.Count < startSize)
			removed = true;
		else
			removed =false;

		return removed;
	}
	
	public bool ContainsBuilding(Building b)
	{
		bool contains = false;
		
		for (int i=0; i<mBuildings.Count; i++) 
		{
			if(mBuildings[i].GetNumber().Equals(b.GetNumber()))
			{
				contains =  true;
				break;
			}
		}
		
		return contains;
	}
}