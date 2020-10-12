using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColorManager : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        float RED_VALUE = 1;
        float GREEN_VALUE = 0f;
        float BLUE_VALUE = 0.3f;
        Color baseColor =new Color( RED_VALUE, GREEN_VALUE,BLUE_VALUE);
        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;
        //Color baseColor = new Color(Random.Range(0f, 0.1f), Random.Range(0f, 0.7f), Random.Range(0.4f, 1f));
        mat.SetColor("_Color", baseColor);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
