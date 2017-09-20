using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickSetSail : MonoBehaviour
{
    public int worldMapSceneIndex;

    public void LoadWorldMap()
    {
        SceneManager.LoadScene(worldMapSceneIndex);
    }
}
