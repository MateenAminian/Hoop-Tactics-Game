using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // public GameObject enemyPlayer1;
    // public GameObject enemyPlayer2;
    // public GameObject enemyPlayer3;
    // public bool BlueTeam;

    // public int moves = 3;
    public static bool hasMoved = false;
    
    public int baseShotChance = 80;
    public int shotChance;
    public int basePassChance = 95;
    public int passChance;
    
    public int baseOffReboundChance = 20;
    public int offReboundChance;
    public int baseDefReboundChance = 80;
    public int defReboundChance;

    public int stealChance = 30;

    public Transform hoop;

    public void movingShot(){
        if (hasMoved == true){
            shotChance = baseShotChance/2;
        }
        //unless movingshot is done next to the hoop (layup)
    }

    public void movingPass(){
        if (hasMoved == true){
            passChance = basePassChance - 10;
        }
    }

    // public void steal(){
    //     // if this player is one hex from enemyPlayer
    //     var enemyDistance = Vector3.Distance(transform.position, enemyPlayer1.transform.position);

    //     //
    //     if (enemyDistance < 1.5f){
    //         int randVal;
    //         randVal = Random.Range(0, 100);
    //         if (randVal < stealChance){
    //             //this player has possession of the ball
    //             Debug.Log("success");
    //         }
    //         else {
    //             Debug.Log("fail");
    //         }
    //     }
    // }

    public void calculateShotChance(){
        var hoopDistance = Vector3.Distance(transform.position, hoop.position);
        if (hoopDistance >= 3.5){
            shotChance = 40;
        }
        else if (hoopDistance < 1.5f){ //layup
            shotChance = baseShotChance;
        }
        else {
            while(hoopDistance > 0.9f){ //dumb way to basically just see how many full tiles away the shooter is from the hoop
                hoopDistance -= 1.0f;
                shotChance = shotChance - 15;
            }
        }
        //40% at the 3 point line (4 hexes distance)
        //80% at the hoop (layup) if 1 hex away from hoop
        //80%-15*(amount of hexes away from hoop)
        //shotChance = finishedcalculation
    }
}
