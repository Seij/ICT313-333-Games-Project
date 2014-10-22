using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Building
{  
	private string mNumber;  
	private string mName;
	private List<string> mOccupants;
	private List<string> mServices;
	
	public Building()
	{
		mNumber = null;
		mName = null;
		mOccupants = new List<string> ();
		mServices = new List<string> ();
	}

	public Building(string num, string name)
	{
		mNumber = num;
		mName = name;
		mOccupants = new List<string> ();
		mServices = new List<string> ();
	}

	public Building(Building b)
	{
		mNumber = b.GetNumber (); 
		mName = b.GetName ();

		foreach (string occupant in b.GetOccupantList()) 
		{
			this.AddOccupant(occupant);
		}

		foreach (string service in b.GetServiceList()) 
		{
			this.AddOccupant(service);
		}
	}

	public bool SetNumber(string num)
	{
		bool isValid;

		if (num != null) 
		{
			mNumber = num;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}
	
	public bool SetName(string name)
	{
		bool isValid;
		
		if (name != null) 
		{
			mName = name;
			isValid = true;
		} 
		else
			isValid = false;
		
		return isValid;
	}

	public string GetNumber()
	{
		return mNumber;
	}

	public string GetName()
	{
		return mName;
	}

	public string GetOccupantAt(int index)
	{
		return mOccupants [index];
	}

	public string GetServiceAt(int index)
	{
		return mServices [index];
	}

	private List<string> GetOccupantList()
	{
		return mOccupants;
	}

	private List<string> GetServiceList()
	{
		return mServices;
	}

	public bool AddOccupant(string occupant)
	{
		bool added;
		int startSize = mOccupants.Count;
		
		if (occupant != null) 
		{
			mOccupants.Add(occupant);

			if(mOccupants.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}

	public bool RemoveOccupant(string occupant)
	{
		bool removed;
		int startSize = mOccupants.Count;
		
		if (occupant != null) 
		{
			mOccupants.Remove(occupant);
			
			if(mOccupants.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}

	public bool ContainsOccupant(string occupant)
	{
		bool contains;
		
		if (occupant != null) 
		{
			mOccupants.Contains(occupant);
			contains = true;
		} 
		else
			contains = false;
		
		return contains;
	}

	public bool AddService(string service)
	{
		bool added;
		int startSize = mServices.Count;
		
		if (service != null) 
		{
			mServices.Add(service);
			
			if(mServices.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}
	
	public bool RemoveService(string service)
	{
		bool removed;
		int startSize = mServices.Count;
		
		if (service != null) 
		{
			mServices.Remove(service);
			
			if(mServices.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}
	
	public bool ContainsService(string service)
	{
		bool contains;
		
		if (service != null) 
		{
			mServices.Contains(service);
			contains = true;
		} 
		else
			contains = false;
		
		return contains;
	}
}