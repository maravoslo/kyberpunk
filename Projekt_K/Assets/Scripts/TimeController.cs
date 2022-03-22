using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Text TimerP;
    [SerializeField] private Text TimerFi;
    [SerializeField] private Text TimerFa;
    public float time;
    float msec;
    float sec;
    float min;
    bool var;

    private void Awake()
    {
        var = true;
    }
    public void EndTimer()
    {
        var = false;
    }
    private void Update()
    {
        if (var)
        {
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            TimerP.text = "Time " + min + ":" + sec + ":" + msec;
            TimerFi.text = "Time " + min + ":" + sec + ":" + msec;
            TimerFa.text = "Time " + min + ":" + sec + ":" + msec;
        }
    }
}
