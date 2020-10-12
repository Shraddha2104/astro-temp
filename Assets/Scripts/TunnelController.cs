using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : MonoBehaviour {
    public float damping = 30;
    float desiredRot;
    int curVertex = 0;
    private float rotationTime;

    public GameObject gm;
    private GameMaster gmScript;

    private void Start()
    {
        gmScript = gm.GetComponent<GameMaster>();
    }

    // Use this for initialization
    private void OnEnable()
    {
        desiredRot = curVertex * 60;
    }

    // Update is called once per frame
    private void Update()
    {
        if( !gmScript.IsGameOver() )
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredRot = curVertex * 60 - 60f;
                curVertex--;
                rotationTime = 0;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredRot = curVertex * 60 + 60f;
                curVertex++;
                rotationTime = 0;
            }
            curVertex = curVertex % 6;
            Quaternion desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);

            rotationTime += Time.deltaTime * damping;
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotQ, rotationTime);
        }
    }
}
