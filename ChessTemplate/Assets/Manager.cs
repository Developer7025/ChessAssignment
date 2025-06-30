using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[,] chessmenPosition = new GameObject[8, 8];

    public GameObject GetPosition(int x, int y)
    {
        return chessmenPosition[x, y];
    }
    public void SetPosition(GameObject Obj, int x, int y) 
    {
        chessmenPosition[x,y] = Obj;
        
    }
}
