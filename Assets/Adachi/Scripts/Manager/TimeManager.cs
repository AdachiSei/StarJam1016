using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    public float Timer => _timer;

    float _timer;
    bool _isCount = true;

    void Update()
    {
        if(_isCount)
        _timer += Time.deltaTime;
    }

    public void StartTimer()
    {
        _isCount = true;
    }

    public void StopTimer()
    {
        _isCount = false;
    }
}
