using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlowMotion : MonoBehaviour
{
    public float slowMotionTimeScale;

    private float startTimeScale;
    private float startFixedDeltaTIme;
    void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTIme = Time.fixedDeltaTime;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            StartSlowMotion();
        }

        if(Input.GetMouseButtonUp(1)){
            StopSlowMotion();
        }
    }

    private void StartSlowMotion(){
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTIme * slowMotionTimeScale * 0.1f;
    }

    public void StopSlowMotion(){
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTIme;
    }
}
