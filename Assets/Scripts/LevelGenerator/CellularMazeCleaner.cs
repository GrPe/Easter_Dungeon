using System;
using System.Collections.Generic;


public static class CellularMazeCleaner
{
    /// <summary>
    /// Clean maze with inaccessible part of corridors and rooms
    /// Use BFS algorithm
    /// </summary>
    /// <param name="maze"></param>
    public static bool[,] Clean(bool[,] maze, int mazeMinSize)
    {

        for (int i = 1; i < maze.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < maze.GetLength(1) - 1; j++)
            {
                bool[,] cleaned = new bool[maze.GetLength(0), maze.GetLength(1)];

                int result = BFS(maze, new Tuple<int, int>(i, j), cleaned);
                if (result >= mazeMinSize)
                {
                    return cleaned;
                }
            }
        }
        return null;
    }

    private static int BFS(bool[,] maze, Tuple<int, int> start, bool[,] cleaned)
    {
        int foundCells = 1;

        cleaned[start.Item1, start.Item2] = true;
        Queue<Tuple<int, int>> points = new Queue<Tuple<int, int>>();
        points.Enqueue(start);

        while (points.Count > 0)
        {
            var point = points.Dequeue();
            int x = point.Item1;
            int y = point.Item2;

            if (x == 0 || x == maze.GetLength(0) - 1) continue;
            if (y == 0 || y == maze.GetLength(1) - 1) continue;

            //up
            if (maze[x + 1, y] && cleaned[x + 1, y] == false)
            {
                points.Enqueue(new Tuple<int, int>(x + 1, y));
                cleaned[x + 1, y] = true;
            }
            //down
            if (maze[x - 1, y] && cleaned[x - 1, y] == false)
            {
                points.Enqueue(new Tuple<int, int>(x - 1, y));
                cleaned[x - 1, y] = true;
            }
            //left
            if (maze[x, y - 1] && cleaned[x, y - 1] == false)
            {
                points.Enqueue(new Tuple<int, int>(x, y - 1));
                cleaned[x, y - 1] = true;
            }
            //right
            if (maze[x, y + 1] && cleaned[x, y + 1] == false)
            {
                points.Enqueue(new Tuple<int, int>(x, y + 1));
                cleaned[x, y + 1] = true;
            }
        }

        return foundCells;
    }
}