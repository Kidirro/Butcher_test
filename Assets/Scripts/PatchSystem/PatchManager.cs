using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchManager : BaseSingleton<PatchManager>
{
    [SerializeField]
    private PatchPoint startPoint;

    private PatchPoint _currentPoint;

    public PatchPoint GetCurrentPoint()
    {
        if (_currentPoint == null)
        {
            _currentPoint = startPoint;
        }

        return _currentPoint;
    }

    public PatchPoint GetNextPoint()
    {
        return GetCurrentPoint().NextPoint;
    }

    public void UpdateNextPoint()
    {
        _currentPoint = GetNextPoint();
    }
    
}
