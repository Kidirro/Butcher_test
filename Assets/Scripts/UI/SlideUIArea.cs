using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUIArea : MonoBehaviour
{

    [SerializeField]
    private SlideType currentType;


    private void Start()
    {
        PlayerMoveController.OnStartMove -= OnStartMove;
        PlayerMoveController.OnEndMove -= OnEndMove;
        
        PlayerMoveController.OnStartMove += OnStartMove;
        PlayerMoveController.OnEndMove += OnEndMove;
        
        gameObject.SetActive(currentType!=SlideType.Finish);
    }

    private void OnDestroy()
    {
        PlayerMoveController.OnStartMove -= OnStartMove;
        PlayerMoveController.OnEndMove -= OnEndMove;
    }

    private void OnEndMove()
    {
        gameObject.SetActive(currentType==SlideType.Finish);
    }

    private void OnStartMove()
    {
        gameObject.SetActive(currentType==SlideType.Gameplay);
    }


    private enum SlideType
    {
        Tutorial,
        Gameplay,
        Finish
    }
}
