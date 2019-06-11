using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AutomataRule
{
    Mazectric,
    Maze
}

public class CellularAutomataGenerator : Generator
{
    private AutomataRule rule;
    private int fulfillment;

    public CellularAutomataGenerator(AutomataRule rule, int fulfillment)
    {
        this.rule = rule;
        this.fulfillment = fulfillment;
    }

    public bool[,] GenerateMaze(int x, int y)
    {
        bool[,] maze = new bool[x, y];

        RandomFillTable(maze);

        Generate(maze, 30);

        return maze;
    }

    private void Generate(bool[,] table, int iteration)
    {
        for (int iter = 0; iter < iteration; iter++)
        {
            var temp = CopyTable(table);
            for (int i = 1; i < table.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < table.GetLength(1) - 1; j++)
                {
                    int neighbors = GetNumberOfAliveNeighbors(temp, i, j);

                    switch (rule)
                    {
                        case AutomataRule.Mazectric:
                            table[i, j] = Mazetric(neighbors, temp[i, j]);
                            break;
                        case AutomataRule.Maze:
                            table[i, j] = Maze(neighbors, temp[i, j]);
                            break;
                    }
                }
            }
        }
    }

    private bool Mazetric(int neighbors, bool actual)
    {
        if (neighbors <= 0 || neighbors >= 5)
        {
            return false;
        }
        else if (neighbors == 3)
        {
            return true;
        }
        else return actual;
    }

    private bool Maze(int neighbors, bool actual)
    {
        if (neighbors <= 0 || neighbors >= 6)
        {
            return false;
        }
        else if (neighbors == 3)
        {
            return true;
        }
        else return actual;
    }

    private void RandomFillTable(bool[,] table)
    {
        fulfillment %= 100;

        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                if (Random.Range(1, 100) <= fulfillment)
                {
                    table[i, j] = true;
                }
            }
        }
    }

    private bool[,] CopyTable(bool[,] table)
    {
        bool[,] ret = new bool[table.GetLength(0), table.GetLength(1)];

        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                ret[i, j] = table[i, j];
            }
        }
        return ret;
    }

    private int GetNumberOfAliveNeighbors(bool[,] table, int x, int y)
    {
        int counter = (table[x, y]) ? -1 : 0;

        for (int i = 0; i < 9; i++)
        {
            counter += (table[i % 3, i / 3]) ? 1 : 0;
        }

        return counter;
    }
}