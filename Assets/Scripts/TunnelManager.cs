using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour {

    public GameObject[] CylinderPrefabs;
    public GameObject bonus;
    public int count=0;
    private List<GameObject> cylindersOnScreen;
    public int maxNumOfFreeCylinders = 5;
    private int curNumOfFreeCylinders;
    private int lastIndex = 0;
    GameMaster gmScript;

    //public const float ZERO = 12, ONE = 3, TWO = 2, THREE = 1, FOUR = 2;

    private Transform playerTransform;
    private float spawnZ = 0f;
    public float offset = 5f;
    private float numOfCylinders = 10;
    public float cylinderLength;

    // Use this for initialization
    void Start()
    {
        count=0;
        cylindersOnScreen = new List<GameObject>();
        curNumOfFreeCylinders = maxNumOfFreeCylinders;

        for (int i = 0; i < numOfCylinders; i++)
            SpawnCylinder();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject gm = GameObject.FindGameObjectWithTag("GameMaster");
        gmScript = gm.GetComponent<GameMaster>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - offset > (spawnZ - numOfCylinders * cylinderLength))
        {
            SpawnCylinder(ChooseIndex(), ChooseAngle());
            DeleteCylinder();

            //add points
            gmScript.IncreamentScore(1);
        }
    }

    private void SpawnCylinder(int prefabIndex = 0, float angle = 0f)
    {
        GameObject cylinder;
        if(count==0){
            prefabIndex=0;
            count++;
        }else if(count==1){
            prefabIndex=1;
            count++;
        }
        cylinder = Instantiate(CylinderPrefabs[prefabIndex]) as GameObject;
        cylinder.transform.SetParent(this.transform);

        cylinder.transform.position = Vector3.forward * spawnZ;

        cylinder.transform.rotation = transform.rotation;
        cylinder.transform.Rotate(0, 0, angle);

        cylindersOnScreen.Add(cylinder);

        PopulateCylinder(prefabIndex, cylinder);

        spawnZ += cylinderLength;
    }

    private void PopulateCylinder(int cylinderID, GameObject cylinder)
    {
        if( cylinderID ==0)
        {
            float spawnChance = Random.Range(0f,1f);
            if (spawnChance >= 0.9f)
                Instantiate(bonus, new Vector3(0,0,spawnZ), Quaternion.Euler(0,0, ChooseAngle()*60f), cylinder.transform);
        }
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

    private int ChooseIndex()
    {
        if (lastIndex == 0 && curNumOfFreeCylinders == 0)
        {
            curNumOfFreeCylinders = maxNumOfFreeCylinders;
            lastIndex = (int)Random.Range(1f, 7);
            return lastIndex;
        }
        else
        {
            curNumOfFreeCylinders--;
            lastIndex = 0;
            return lastIndex;
        }
    }

    private float ChooseAngle()
    {
        return 60f * (int)Random.Range(0f, 5);
    }
}
