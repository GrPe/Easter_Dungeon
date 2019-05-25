using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AutomataRule rule;
    [SerializeField] private int fulfillment;
    [SerializeField] private Vector2 levelSize;

    [SerializeField] private Vector2 floorSize;
    [SerializeField] private GameObject floor;


    private void Awake()
    {
        Generator generator = new CellularAutomataGenerator(rule, fulfillment);

        var maze = generator.GenerateMaze((int)levelSize.x, (int)levelSize.y);

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); i++)
            {
                Instantiate(floor, new Vector3(i * floorSize.x, 0, j * floorSize.y), Quaternion.identity);
            }
        }
    }
}
