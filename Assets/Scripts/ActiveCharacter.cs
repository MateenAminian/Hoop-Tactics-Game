using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    public CharacterMovement CharacterA;
    public CharacterMovement CharacterB;
    public CharacterMovement CharacterC;
    public CharacterMovement CharacterD;
    public CharacterMovement CharacterE;
    public CharacterMovement CharacterF;

    MouseInput mouseInput;

    private state State;
    private state NextState;

    // blue or red
    public float Turn = 1;


    private CharacterMovement curPlayer = null;

    private enum state{
        TurnA,
        TurnB,
        TurnC,
        TurnD,
        TurnE,
        TurnF,
    }

    private void Awake() {
        mouseInput = new MouseInput();
        mouseInput.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        // will remove this once selection is done
        // updateState(state.TurnA);
        // Activate(curPlayer);
        CharacterA.hasBall = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        // need to set a new player
        if(curPlayer == null)
        {
            mouseInput.Enable();
            if(CharacterA.takenTurn && CharacterB.takenTurn && CharacterC.takenTurn){
                Turn = 2;
                UIManager.setTurnIndicator_Static(true);
                UIManager.updateTurnsLeft_Static();
                CharacterA.takenTurn = false;
                CharacterB.takenTurn = false;
                CharacterC.takenTurn = false;
            }

            if(CharacterD.takenTurn && CharacterE.takenTurn && CharacterF.takenTurn){
                Turn = 1;
                UIManager.setTurnIndicator_Static(false);
                UIManager.updateTurnsLeft_Static();
                CharacterD.takenTurn = false;
                CharacterE.takenTurn = false;
                CharacterF.takenTurn = false;
            }

            mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
        }
        // if has a player selected wait till turn is done
        else
        {
            mouseInput.Disable();
            if(CheckTaken(curPlayer))
            {
                Deactivate(curPlayer);
                curPlayer = null;
            }
        } 

    }

    void Activate(CharacterMovement Char)
    {
        Char.curTurn = true;
    }

    void Deactivate(CharacterMovement Char)
    {
        Char.curTurn = false;
    }

    bool CheckTaken(CharacterMovement Char)
    {
        if(Char.curTurn && Char.takenTurn){
            return true;
        }
        return false;
    }
    public CharacterMovement getActiveCharacter(){
        return curPlayer;
    }
    public float calcShot(CharacterMovement shooter){
        float retVal;
        var hoopDistance = Vector3.Distance(shooter.transform.position, shooter.hoop.position);
        retVal = (hoopDistance/6f)*100f;
        if(shooter.team == 1)
        {
            if(Vector3.Distance(shooter.transform.position, CharacterD.transform.position)<1.3)
            {
                retVal += 10;
            }
            if(Vector3.Distance(shooter.transform.position, CharacterE.transform.position)<1.3)
            {
                retVal += 10;
            }
            if(Vector3.Distance(shooter.transform.position, CharacterF.transform.position)<1.3)
            {
                retVal += 10;
            }
        }
        else
        {
            if(Vector3.Distance(shooter.transform.position, CharacterA.transform.position)<1.3)
            {
                retVal += 10;
            }
            if(Vector3.Distance(shooter.transform.position, CharacterB.transform.position)<1.3)
            {
                retVal += 10;
            }
            if(Vector3.Distance(shooter.transform.position, CharacterC.transform.position)<1.3)
            {
                retVal += 10;
            }
        }

        return retVal;
    }

    public void goal(float team,float score){
        // update ui here
        if(team == 1)
        {
            // update blue ui with score
            UIManager.updateScoreText_Static(false, (int)score );
        }
        else
        {
            // update red ui with score
            UIManager.updateScoreText_Static(true, (int)score );
        }
        CharacterA.gotospawn();
        CharacterB.gotospawn();
        CharacterC.gotospawn();
        CharacterD.gotospawn();
        CharacterE.gotospawn();
        CharacterF.gotospawn();
        UIManager.updateTurnsLeft_Static();
        if(team == 1)
        {
            Turn = 2;
            UIManager.setTurnIndicator_Static(true);
            CharacterE.hasBall = true;
            CharacterA.takenTurn = false;
            CharacterB.takenTurn = false;
            CharacterC.takenTurn = false;
        }
        else
        {
            Turn = 1;
            UIManager.setTurnIndicator_Static(false);
            CharacterA.hasBall = true;
            CharacterD.takenTurn = false;
            CharacterE.takenTurn = false;
            CharacterF.takenTurn = false;
        }
        Deactivate(curPlayer);
        curPlayer = null;
    }

    private void MouseClick() {
        //this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        Vector2 mousePos = (mouseInput.Mouse.MousePosition.ReadValue<Vector2>());
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        // hit.collider store rigidbody and gameobject clicked 
        if (hit.collider != null){
            if (hit.collider.tag == "Basket"){
                Debug.Log("Shoot at basket");
                return;
            }
            if(hit.transform.GetComponent<CharacterMovement>().team == Turn){
                //Debug.Log("correct team");
                if(!hit.transform.GetComponent<CharacterMovement>().takenTurn)
                {
                    //Debug.Log("available");
                    hit.transform.GetComponent<CharacterMovement>().curTurn = true;
                    curPlayer = hit.transform.GetComponent<CharacterMovement>();
                }
                
            }
            //Debug.Log("clicked player");
        }
    }
}