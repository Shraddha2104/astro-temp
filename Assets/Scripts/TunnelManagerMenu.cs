       using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManagerMenu : MonoBehaviour
{

    public GameObject[] CylinderPrefabs;
    private List<GameObject> cylindersOnScreen;
    public int maxNumOfFreeCylinders = 5;
    private int curNumOfFreeCylinders;
    private int lastIndex = 0;
    GameMasterMenu gmScript;

    //public const float ZERO = 12, ONE = 3, TWO = 2, THREE = 1, FOUR = 2;

    private Transform playerTransform;
    private float spawnZ = 0f;
    public float offset = 5f;
    private float numOfCylinders = 10;
    public float cylinderLength;

    // Use this for initialization
    void Start()
    {
        cylindersOnScreen = new List<GameObject>();
        curNumOfFreeCylinders = maxNumOfFreeCylinders;

        for (int i = 0; i < numOfCylinders; i++)
            SpawnCylinder();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject gm = GameObject.FindGameObjectWithTag("GameMaster");
        gmScript = gm.GetComponent<GameMasterMenu>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - offset > (spawnZ - numOfCylinders * cylinderLength))
        {
            SpawnCylinder();
            DeleteCylinder();

            //add points
            gmScript.IncreamentScore(1);
        }
    }

    private void SpawnCylinder(int prefabIndex = 0, float angle = 0f)
    {
        GameObject cylinder;
        cylinder = Instantiate(CylinderPrefabs[prefabIndex]) as GameObject;
        cylinder.transform.SetParent(this.transform);

        cylinder.transform.position = Vector3.forward * spawnZ;

        cylinder.transform.rotation = transform.rotation;
        cylinder.transform.Rotate(0, 0, angle);

        cylindersOnScreen.Add(cylinder);

        //PopulateCylinder(prefabIndex, cylinder);

        spawnZ += cylinderLength;
    }

    private void DeleteCylinder()
    {
        Transform t = cylindersOnScreen[0].transform;
        foreach (Transform child in t)
        {
            GameObject.Destroy(child.gameObject);
        }
        Destroy(cylindersOnScreen[0]);
        cylindersOnScreen.RemoveAt(0);
    }
}
