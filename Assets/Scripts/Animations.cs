using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
      //Just a test to make sure the uodate works
      //animate.SetFloat("shooting", 2);
    }

    // Update is called once per frame
    void Update()
    {
      if (animate.GetCurrentAnimatorStateInfo(0).IsName("BallShot") || animate.GetCurrentAnimatorStateInfo(0).IsName("BallClose")){
        animate.SetFloat("shooting", 1);
        this.transform.position = new Vector3(0, -1, -9);
      } else if (animate.GetCurrentAnimatorStateInfo(0).IsName("BallPass")) {
        animate.SetBool("passing", false);
        this.transform.position = new Vector3(0, -1, -9);
      }
      else if (animate.GetCurrentAnimatorStateInfo(0).IsName("BallFailed")) {
        animate.SetBool("missedShot", false);
        this.transform.position = new Vector3(0, -1, -9);
      }
      else {
        this.transform.position = new Vector3(14, -1, -9);
      }
    }
}
