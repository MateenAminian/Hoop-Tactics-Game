using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    public Tilemap map;
    MouseInput mouseInput;
    private Vector3 destination;
    public bool curTurn = false;
    public bool takenTurn = false;
    public bool hasBall = false;
    [SerializeField] private float moveSpeed = 5.0f;
    public float team;
    public GameObject spawn;
    public ActiveCharacter GameControls;
    public bool active = false;
    public GameObject foundSquare;
    public Animator animate;

    // public bool stealUsed = false;
    // public float enemyTeam;

    // public bool blueTeam;

    public Transform hoop;
    public Rebound hoopRebound;
    // public GameObject playerClass;


    private void Awake() {
        mouseInput = new MouseInput();
        gotospawn();
    }

    private void OnEnable(){
        mouseInput.Enable();
    }

    private void OnDisable(){
        mouseInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        //this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
        foundSquare = GameObject.Find("Square");
    }

    private void MouseClick() {
        if(curTurn)
        {
            //this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            Vector2 mousePos = (mouseInput.Mouse.MousePosition.ReadValue<Vector2>());
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            // hit.collider store rigidbody and gameobject clicked
            if (hit.collider != null){
                if(hasBall){
                    if (hit.collider.tag == "Basket"){
                        Debug.Log("shoot shot");
                        this.hasBall = false;
                        //Debug.Log(hasBall);
                        this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
                        takenTurn = true;
                        var hoopDistance = Vector3.Distance(transform.position, hoop.position);
                        var rng = Random.Range(0,100);
                        var toBeat = GameControls.calcShot(this);
                        Debug.Log("Rolling: "+(rng+10)+">"+toBeat);
                        if(rng+10>toBeat)
                        {
                            float score = 2;
                            if(hoopDistance > 3)
                            {
                                animate.SetFloat("shooting", 2);
                                foundSquare.transform.position = new Vector3(0, -1, -9);
                                score = 3;
                            }
                            else {
                              animate.SetFloat("shooting", 0);
                              foundSquare.transform.position = new Vector3(0, -1, -9);
                            }
                            Debug.Log("GOAL: "+score);
                            // reset the area
                            GameControls.goal(team, score);

                        }
                        else
                        {
                            animate.SetBool("missedShot", true);
                            foundSquare.transform.position = new Vector3(0, -1, -9);
                            Debug.Log("Rebound");
                            hoopRebound.Calculate();
                        }


                        return;
                    }
                    hit.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 0;
                    //Debug.Log(hit.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder);
                    this.hasBall = false;
                    if (hit.transform != this.gameObject.transform){

                        animate.SetBool("passing", true);
                        foundSquare.transform.position = new Vector3(0, -1, -9);
                        this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
                        Debug.Log("passed the ball");
                        return;
                    }

                    Debug.Log("clicked on self");
                    return;
                }
                else { //stealing test if enemy team, and if enemy player has ball, turn off enemy player having ball
                    if (hit.collider.tag == "Basket"){
                        Debug.Log("You dont have the ball!");
                        return;
                    }
                    var targetDistance = Vector3.Distance(transform.position, hit.transform.position);
                    var targetHasBall = hit.transform.GetComponent<CharacterMovement>().hasBall;

                    if (targetDistance < 1.5f && targetHasBall && (hit.collider.tag != this.gameObject.tag)){
                        if (steal()){
                            this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 0;
                            hit.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
                        // hit.hasBall = false;
                            hit.transform.GetComponent<CharacterMovement>().hasBall = false;
                        }
                    }

                }

                // Debug.Log(enemyDistance);

                //hasBall = true;
            }


            if (hit.collider == null){
                Debug.Log("clicked to move");
                // make sure we are clicking the cell
                Vector3Int gridPos = map.WorldToCell(mousePos);
                if (map.GetCellCenterWorld(gridPos).y > 4){
                    //destination = map.GetCellCenterWorld(gridPos);
                    Debug.Log("out of bounds");
                    return;
                }
                destination = map.GetCellCenterWorld(gridPos);
                //Debug.Log(destination);
            }



            //change the hasMoved variable to true
            /*
            switch(gameObject.tag){
                case guard:
                    Guard.hasMoved = true;
                    break;
                case forward:
                    Forward.hasMoved = true;
                    break;
                case center:
                    Center.hasMoved = true;
                    break;
            }*/

            if (Vector3.Distance(transform.position, destination) > 0.1f && Vector3.Distance(transform.position, destination) < 3.5f){
                takenTurn = true;

            }

            //reset steal variable
            // stealUsed = false;

        }

    }

    public bool steal(){
        // if this player is one tile from enemyPlayer
        // var enemyDistance = Vector3.Distance(transform.position, enemyPlayer1.transform.position);

            int randVal;
            randVal = Random.Range(0, 100);
            if (randVal < 30){
                //this player has possession of the ball
                Debug.Log("stolen");
                takenTurn = true;
                return true;

            }
            else {
                Debug.Log("failed to steal");
                takenTurn = true;
                return false;
            }
        // }
    }

    private bool canShoot(){
        var distance = Vector3.Distance(transform.position, hoop.position);
        // print(distance);
        //check if the current player is close enough to shoot. (4.5 is right around the midpoint between the half court and the 3 point line)
        if(distance < 4.5f ){
            return true;
        }
        else{
            return false;
        }
    }

    public void gotospawn(){
        Vector3Int gridPos = map.WorldToCell(spawn.transform.position);
        destination = map.GetCellCenterWorld(gridPos);
        this.transform.position = destination;
    }

    // Update is called once per frame
    void Update()
    {
        animate = foundSquare.GetComponent<Animator>();
        if (Vector3.Distance(transform.position, destination) > 0.1f && Vector3.Distance(transform.position, destination) < 3.5f){
            // check if destination has a unit on the tile already before moving
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            // print(canShoot());

        }
        if (curTurn){
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        }

        if(!takenTurn && GameControls.Turn == this.team){
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
        else{
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        if (this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder == 0){
            hasBall = true;
        }

        if (this.hasBall){
            this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 0;
        } else if(this.hasBall == false) {
            this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
        }

        if(GetComponent<SpriteRenderer>().enabled){
            //this.hasBall = true;
        }
    }
}
