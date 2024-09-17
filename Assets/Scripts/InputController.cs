using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : BaseSingleton<InputController>
{
    public static event Action<float> OnHorizontalDrag = delegate(float f) {  };

    private bool _isDrag;
    private Vector2 _previousPoint; 
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isDrag == false)
        {
            _isDrag = true;
            _previousPoint = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButtonUp(0) && _isDrag)
        {
            _isDrag = false;
            return;
        }

        if (!_isDrag) return;
        
        Vector3 currentPoint = Input.mousePosition;
        OnHorizontalDrag.Invoke(currentPoint.x - _previousPoint.x);
        _previousPoint = currentPoint;
    }
}
