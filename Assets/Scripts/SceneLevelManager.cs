using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelManager : BaseSingleton<SceneLevelManager>
{
    [SerializeField]
    private int nextSceneId;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneId);
    }
}
