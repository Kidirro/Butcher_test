using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    [SerializeField]
    private GameObject trainObject;

    [SerializeField]
    private Collider playerCollider;

    [Space, Min(0), SerializeField]
    private float _forwardSpeed;

    [Min(0), SerializeField]
    private float _horizontalSpeed;

    [Min(0), SerializeField]
    private float _rotationSpeed;

    private bool _rotationInProgress = false;
    private bool _isFinish = false;
    
  private void Start()
  {
     InputController.OnHorizontalDrag -= OnDragged;
     InputController.OnHorizontalDrag += OnDragged;
     
     UpdateTrainPositionForced();
     ColliderController.Instance.RegisterPlayerCollider(playerCollider);
  }

  private void Update()
  {
      if (_isFinish) return;;
      if (_rotationInProgress) return;
      var currentPoint = PatchManager.Instance.GetCurrentPoint();
      if (currentPoint.NextPoint == null)
      {
          _isFinish = true;
          return;
      }

      trainObject.transform.position += trainObject.transform.forward * Time.deltaTime * _forwardSpeed;
      
      //При доходе до следующей точки запуск анимации и следующей точки
      if ((trainObject.transform.position - currentPoint.NextPoint.transform.position).sqrMagnitude <= 0.1f)
      {
          PatchManager.Instance.UpdateNextPoint();
          if (PatchManager.Instance.GetCurrentPoint() == null) return;
          UpdateTrainPosition();
      }
  }

  private void UpdateTrainPositionForced()
  {
      var point = PatchManager.Instance.GetCurrentPoint().transform;
      trainObject.transform.position = point.position;
      trainObject.transform.forward = point.forward;
  }

  private void UpdateTrainPosition()
  {
      StartCoroutine(RotationProcess());
  }

  private void OnDestroy()
  {
      InputController.OnHorizontalDrag -= OnDragged;
  }

  private void OnDragged(float delta)
  {
      if (delta == 0) return;
      if (_isFinish) return;

      float width = PatchManager.Instance.GetCurrentPoint().Width;
      var localPosition = player.transform.localPosition;
      float position = Mathf.Clamp(localPosition.x + delta * Time.deltaTime * _horizontalSpeed, -width,width);
      player.transform.localPosition = new Vector3(position, localPosition.y, localPosition.z);
  }

  private IEnumerator RotationProcess()
  {
      _rotationInProgress = true;
      
      var currentPointVector = PatchManager.Instance.GetCurrentPoint().transform.forward;
      while ((trainObject.transform.forward - currentPointVector).sqrMagnitude>0.01f)
      {
          trainObject.transform.forward = Vector3.Lerp(trainObject.transform.forward,currentPointVector, Time.deltaTime* _rotationSpeed);
          
          yield return null;
      }

      trainObject.transform.forward = PatchManager.Instance.GetCurrentPoint().transform.forward;
      _rotationInProgress = false;
  }
}
