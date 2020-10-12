using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpaceship : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode moveL;
    public KeyCode moveR;
    public float horizVel=0 ;
    public int laneNum=2;
    public string controlLocked="n";
    void Start()
    {
        // GetComponent<Rigidbody>().velocity = new Vector3(0,0,5);
    }

    // Update is called once per frame
    void Update()
    {
    	GetComponent<Rigidbody>().velocity = new Vector3(horizVel,0,5);
    	if((Input.GetKeyDown(moveL))&&(laneNum>1)&&(controlLocked=="n")){
    		horizVel-=2;
    		StartCoroutine(stopSlide());
    		laneNum-=1;
    		controlLocked="y";
    	}
    	if((Input.GetKeyDown(moveR))&&(laneNum<3)&&(controlLocked=="n")){
    		horizVel=2;
    		StartCoroutine(stopSlide());
    		laneNum+=1;
    		controlLocked="y";
    	}
        
    }
    IEnumerator stopSlide(){
    	yield return new WaitForSeconds(.5f);
    	horizVel=0;
    	controlLocked="n";
    }
}
