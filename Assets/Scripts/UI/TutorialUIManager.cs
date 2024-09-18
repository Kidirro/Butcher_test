using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    private void Start()
    {
        PlayerMoveController.OnStartMove-= OnEndTutorial;
        PlayerMoveController.OnStartMove+= OnEndTutorial;
    }

    private void OnDestroy()
    {
        PlayerMoveController.OnStartMove-= OnEndTutorial;
    }

    private void OnEndTutorial()
    {
        Destroy(gameObject);
    }
}
