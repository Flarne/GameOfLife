using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

	public bool alive = false;
	public int numberLivingNeighbours;

	public void SetState ()
	{
		if (alive)
		{
			GetComponent<MeshRenderer>().enabled = true;
		}
		else
		{
			GetComponent<MeshRenderer>().enabled = false;
		}
	}

	public void SetAlive(bool alive)
	{
		this.alive = alive;
		SetState();
	}
}
