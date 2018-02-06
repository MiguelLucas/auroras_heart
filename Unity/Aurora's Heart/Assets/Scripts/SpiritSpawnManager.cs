using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSpawnManager : MonoBehaviour {

    public int nbSpirits;
    public GameObject spirit;
    public Transform parent;

    private class SpawnArea
    {
        public float xTop, xBottom, zTop, zBottom;

        public SpawnArea(float xTop, float xBottom, float zTop, float zBottom)
        {
            this.xTop = xTop;
            this.xBottom = xBottom;
            this.zTop = zTop;
            this.zBottom = zBottom;
        }
    }

    private List<SpawnArea> areas;
    private static float height = 7;
    private int spiritsperArea;

	// Use this for initialization
	void Start () {

        areas = new List<SpawnArea>();
        areas.Add(new SpawnArea(220, 59, 47, -106));
        areas.Add(new SpawnArea(352, 191, -106, -282));
        areas.Add(new SpawnArea(191, 30, -106, -282));
        areas.Add(new SpawnArea(30, -161, -106, -282));
        areas.Add(new SpawnArea(-161, -292, -106, -282));

        spiritsperArea = nbSpirits / areas.Count;
        foreach(SpawnArea area in areas)
        {
            for(int i=0; i < spiritsperArea; i++)
            {
                Vector3 pos = new Vector3(Random.Range(area.xBottom, area.xTop), spirit.transform.position.y, Random.Range(area.zBottom, area.zTop));
                Instantiate(spirit, pos, Quaternion.identity, parent);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
