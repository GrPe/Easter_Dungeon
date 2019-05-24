using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Generator
{
    bool[,] GenerateMaze(int x, int y);
}
