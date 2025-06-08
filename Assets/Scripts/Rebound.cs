using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebound : MonoBehaviour
{
    public ActiveCharacter GameControls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Calculate()
    {
        var ADistance = Vector3.Distance(transform.position, GameControls.CharacterA.transform.position);
        var BDistance = Vector3.Distance(transform.position, GameControls.CharacterB.transform.position);
        var CDistance = Vector3.Distance(transform.position, GameControls.CharacterC.transform.position);
        var DDistance = Vector3.Distance(transform.position, GameControls.CharacterD.transform.position);
        var EDistance = Vector3.Distance(transform.position, GameControls.CharacterE.transform.position);
        var FDistance = Vector3.Distance(transform.position, GameControls.CharacterF.transform.position);
        var shortest = ADistance;
        CharacterMovement closest = GameControls.CharacterA;
        if(BDistance < shortest)
        {
            shortest = BDistance;
            closest = GameControls.CharacterB;
        }
        if(CDistance < shortest)
        {
            shortest = CDistance;
            closest = GameControls.CharacterC;
        }
        if(DDistance < shortest)
        {
            shortest = DDistance;
            closest = GameControls.CharacterD;
        }
        if(EDistance < shortest)
        {
            shortest = EDistance;
            closest = GameControls.CharacterE;
        }
        if(FDistance < shortest)
        {
            shortest = FDistance;
            closest = GameControls.CharacterF;
        }

        // closest recieves the rebound
        if(closest.team == GameControls.Turn)
        {
            // teammate got rebound
            closest.hasBall = true;
        }
        else{
            // opponent got rebound
            closest.hasBall = true;
        }

    }
}
