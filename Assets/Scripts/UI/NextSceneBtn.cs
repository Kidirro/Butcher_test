using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBtn : MonoBehaviour
{
    public void OpenNextScene()
    {
        SceneLevelManager.Instance.LoadNextLevel();
    }
}
