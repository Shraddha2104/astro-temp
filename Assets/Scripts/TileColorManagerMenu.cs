using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorManagerMenu : MonoBehaviour
{
    Renderer rend;
    Material mat;
    Color baseColor;
    public GameMasterMenu gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMasterMenu>();
        rend = GetComponent<Renderer>();
        mat = rend.material;
        baseColor = new Color(Random.Range(gm.values[0], gm.values[1]),
            Random.Range(gm.values[2], gm.values[3]),
            Random.Range(gm.values[4], gm.values[5]));

        mat.SetColor("_EmissionColor", baseColor);
    }
}