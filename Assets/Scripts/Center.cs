using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{


    public float moves = 4.0f;
    public bool hasMoved = false;
    
    public float baseShotChance = 0.75f;
    public float shotChance;
    public float basePassChance = 0.95f;
    public float passChance;
    
    public float baseOffReboundChance = 0.30f;
    public float offReboundChance;
    public float baseDefReboundChance = 0.90f;
    public float defReboundChance;

    public float stealChance = 0.20f;

    public void movingShot(){
        if (hasMoved == true){
            shotChance = baseShotChance/2;
        }
    }

    public void movingPass(){
        if(hasMoved == true){
            passChance = basePassChance - 0.10f;
        }
    }
}
