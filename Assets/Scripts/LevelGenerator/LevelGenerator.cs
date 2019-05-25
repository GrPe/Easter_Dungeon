using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AutomataRule rule;
    [SerializeField] private int fulfillment;
    [SerializeField] private Vector2 levelSize;
    [SerializeField] private int minSize = 30;

    [SerializeField] private Vector2 floorSize;
    [SerializeField] private GameObject floor;

    [SerializeField] private Vector2 wallSize;
    [SerializeField] private GameObject wall;

    public bool ok = false;


    private void Start()
    {
        if (ok) return;
        ok = true;

        Generator generator = new CellularAutomataGenerator(rule, fulfillment);

        var temp = generator.GenerateMaze((int)levelSize.x, (int)levelSize.y);

        var maze = CellularMazeCleaner.Clean(temp, minSize);

        for (int i = 1; i < maze.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < maze.GetLength(1) - 1; j++)
            {
                if (maze[i, j])
                {
                    var instance = Instantiate(floor, new Vector3(i * floorSize.x, 0, j * floorSize.y), Quaternion.identity, transform);
                    CreateWalls(maze, i, j, instance.transform);
                }
            }
        }
    }

    private void CreateWalls(bool[,] maze, int x, int y, Transform parent)
    {
        //up
        if (!maze[x + 1, y] || x + 1 == maze.GetLength(0) - 1)
        {
            Instantiate(wall, new Vector3(x * wallSize.x + wallSize.x, 0, y * wallSize.y + wallSize.y), Quaternion.Euler(0, 180, 0), parent);
        }
        //down
        if (!maze[x - 1, y] || x - 1 == 0)
        {
            Instantiate(wall, new Vector3(x * wallSize.x, 0, y * wallSize.y), Quaternion.Euler(0, 0, 0), parent);
        }
        //right ++
        if (!maze[x, y + 1] || y + 1 == maze.GetLength(1) - 1)
        {
            Instantiate(wall, new Vector3(x * wallSize.x, 0, y * wallSize.y + wallSize.y), Quaternion.Euler(0, 90, 0), parent);
        }
        //left 
        if (!maze[x, y - 1] || y - 1 == 0)
        {
            Instantiate(wall, new Vector3(x * wallSize.x + wallSize.x, 0, y * wallSize.y), Quaternion.Euler(0, 270, 0), parent);
        }
    }
}
