using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTerrain : MonoBehaviour
{

    [SerializeField]
    private Terrain leftT;
    [SerializeField]
    private Terrain topT;
    [SerializeField]
    private Terrain rightT;
    [SerializeField]
    private Terrain bottomT;

    Terrain thisTerrain;

    // Use this for initialization
    void Start()
    {

        thisTerrain = this.GetComponent<Terrain>();
        thisTerrain.SetNeighbors(leftT, topT, rightT, bottomT);
    }

}
