using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{

	public int spawnProcentage = 30;
	public int numberOfCells = 10;
	public float tick;
	float nextTick = 0;

	public GameObject cellPrefab;
	Cell[,] cells;

	int gridX;
	int gridY;

	// Use this for initialization
	void Start () {
		gridX = numberOfCells;
		gridY = numberOfCells;

		cells = new Cell[gridX, gridY];

		for (int y = 0; y < gridY; y++)
		{
			for (int x = 0; x < gridX; x++)
			{
				Vector3 spawnOffset = new Vector3(x, 0, y);
				GameObject newCell = Instantiate(cellPrefab, transform.position + spawnOffset, transform.rotation, transform);
				cells[x, y] = newCell.GetComponent<Cell>();
				cells[x, y].SetAlive(false);
				if (Random.Range(0, 100) < spawnProcentage)
				{
					cells[x, y].SetAlive(true);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(nextTick > tick)
		{
			CheckAliveCells();
			CheckRules();
			Debug.Log("Tick");
			// Do Stuff
			nextTick -= tick;
		}
		nextTick += Time.deltaTime;
	}

	void CheckAliveCells()
	{
		// Kollar antal levande på varje rad
		for (int y = 0; y < gridY; ++y)
		{
			// Kollar antal levande i varje kolumn på varje rad
			for (int x = 0; x < gridX; ++x)
			{
				cells[x, y].numberLivingNeighbours = CheckNeighbour(x, y);
			}
		}
	}

	void CheckRules()
	{
		// Kollar reglerna för varje rad
		for (int y = 0; y < gridY; ++y)
		{
			// Kollar reglerna för varje kolumn på varje rad
			for (int x = 0; x < gridX; ++x)
			{
				cells[x, y].SetAlive(CheckIfAlive(x, y));
			}
		}
	}

	public int CheckNeighbour(int x, int y)
	{
		int aliveNeighbours = 0;

		// Kollar Hur många levande grannar i x-led
		for (int i = -1; i <= 1; i++)
		{
			// Kollar Kanterna på sidorna
			if (x + i >= 0 && x + i < gridY)
			{
				// Kollar hur många levande grannar i y-led
				for (int j = -1; j <= 1; j++)
				{
					// kollar kanterna uppe och nere
					if (y + j >= 0 && y + j < gridX)
					{
						// Kollar om det är Origo och hoppar över den
						if (cells[x + i, y + j].alive && !(i == 0 && j == 0))
						{
							// Om det är Origo plussas aliveNeighbours med ett och går till nästa
							aliveNeighbours++;
						}
					}
				}
			}
		}
		// Sparar och skickar levande till draw
		return aliveNeighbours;
	}

	public bool CheckIfAlive(int x, int y)
	{

		// Kollar om cellen har 0 eller 1 granne dvs död pga underbefolkning
		if (cells[x, y].numberLivingNeighbours < 2)
		{
			return false;
		}
		// Kollar om cellen har 3 eller mer grannar dvs död pga överbefolkning
		else if (cells[x, y].numberLivingNeighbours > 3)
		{
			return false;
		}
		// Kollar om cellen lever, då lever den till nästa generation
		else if (cells[x, y].alive)
		{
			return true;
		}
		// Kollar om en död cell har 3 grannar och då produceras en ny cell
		if (cells[x, y].numberLivingNeighbours == 3 && !cells[x, y].alive)
		{
			//populationFrame++;
			return true;
		}
		else
		{
			return false;
		}
	}
}
