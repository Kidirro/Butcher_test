using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
   [SerializeField]
   private Animator _animator;

   private readonly int onStartHash = Animator.StringToHash("OnStart");
   private readonly int onEndHash = Animator.StringToHash("OnEnd");

   private void Start()
   {
      PlayerMoveController.OnStartMove -= OnStartMove;
      PlayerMoveController.OnEndMove -= OnEndMove;
      
      PlayerMoveController.OnStartMove += OnStartMove;
      PlayerMoveController.OnEndMove += OnEndMove;
   }

   private void OnStartMove()
   {
      _animator.SetTrigger(onStartHash);
   }

   private void OnEndMove()
   {
      _animator.SetTrigger(onEndHash);
   }
}
