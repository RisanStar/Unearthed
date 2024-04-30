using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int Wirelevel;
    public float[] position;

   public PlayerData(Puzzle1 pos)
    {
        Wirelevel = pos.Wirelevel;

        position = new float[3];
        position[0] = pos.transform.position.x;
        position[1] = pos.transform.position.y;
        position[2] = pos.transform.position.z; 


    }
}
