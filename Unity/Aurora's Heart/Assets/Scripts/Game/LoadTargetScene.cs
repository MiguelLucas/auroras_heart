using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTargetScene : MonoBehaviour {

	public void LoadSceneNum(int num)
    {

        Debug.Log("Loading target scene");
        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Can't load scene number " + num + ", SceneManager only has " + SceneManager.sceneCountInBuildSettings + " scenes in BuildSettings!");
        }

        print(SceneManager.sceneCountInBuildSettings + " scenes in build settings");
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            print("Scene -> " + SceneManager.GetSceneByBuildIndex(i).name);

        LoadingScreenManager.LoadScene(num);

        print(SceneManager.sceneCountInBuildSettings + " scenes in build settings");
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            print("Scene -> " + SceneManager.GetSceneByBuildIndex(i).name);

        GameManager.gameManager.changePlayerPositionFromForestToCave();

    }
}
