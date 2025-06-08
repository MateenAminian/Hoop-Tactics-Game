using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject text;
      public GameObject background;
      public ActiveCharacter temp;
      int percent = 0;
    void Awake(){
        text.SetActive(false);
        background.SetActive(false);
    }
    public void OnMouseOver()
    {
        
        if(temp.getActiveCharacter() !=null && temp.getActiveCharacter().hasBall == true){
            print(temp.calcShot(temp.getActiveCharacter()));
            float chance = temp.calcShot(temp.getActiveCharacter());
            print("this is the chance " + chance);
            if(chance > 110.0f){
                percent = 0;
            }
            else{
                percent = 110 - (int)chance;
            }
            // print("Chance to go in is: " + percent);
            text.SetActive(true);
            background.SetActive(true);
            PercentHover.ShowHover_Static(percent);
        }
        
        
    }

    public void OnMouseExit(){
        text.SetActive(false);
        background.SetActive(false);

    }
}
