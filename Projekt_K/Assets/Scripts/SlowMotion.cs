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
        if(Input.GetMouseButtonDown(0)){
            StartSlowMotion();
        }

        if(Input.GetMouseButtonUp(0)){
            StopSlowMotion();
        }
    }

    private void StartSlowMotion(){
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTIme * slowMotionTimeScale;
    }

    public void StopSlowMotion(){
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTIme;
    }
}
