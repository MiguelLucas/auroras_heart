using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{

    [SerializeField]
    private LoadTargetScene targetScene;
    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float yPosition;
    [SerializeField]
    private float zPosition;
    [SerializeField]
    private Vector3 playerTransformMenuToForest;
    [SerializeField]
    private Vector3 playerTransformForestToCave;
    [SerializeField]
    private Vector3 playerTransformCaveToForest;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(3, 8, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Scene Changer: COLIDIU " + other.tag + other.name);
        if(other.GetComponent<Collider>().name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            //changeScene
            //changeScene

        }

        if (other.tag == "Player") {
            changeScene(3);
        }
    }

    private void changeScene(int num) {
        //other.transform.position = playerTransform;
        targetScene.LoadSceneNum(num);
    }


}



