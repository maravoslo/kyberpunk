using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Text TimerP;
    [SerializeField] private Text TimerFi;
    [SerializeField] private Text TimerFa;
    [SerializeField] private GameObject Star0;
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private string LevelName;
    public GameObject PanelFinish;
    public GameObject PanelFailed;
    public float time;
    float msec;
    float sec;
    float min;
    bool var;
    
    private void Awake()
    {
        Star0.gameObject.SetActive(false);
        Star1.gameObject.SetActive(false);
        Star2.gameObject.SetActive(false);

        PlayerPrefs.SetInt("Star0" + LevelName, 0);
        PlayerPrefs.SetInt("Star1" + LevelName, 0);
        PlayerPrefs.SetInt("Star2" + LevelName, 0);

        var = true;
    }
    public void EndTimer()
    {
        var = false;

        if (time <= 15)
        {
            Star0.gameObject.SetActive(true);
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Star0" + LevelName, 1);
            PlayerPrefs.SetInt("Star1" + LevelName, 1);
            PlayerPrefs.SetInt("Star2" + LevelName, 1);

        }
        else if (time > 15 && time <= 20)
        {
            Star0.gameObject.SetActive(true);
            Star1.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Star0" + LevelName, 1);
            PlayerPrefs.SetInt("Star1" + LevelName, 1);
            PlayerPrefs.SetInt("Star2" + LevelName, 0);
        }
        else if (time > 20 && time <= 25)
        {
            Star0.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Star0" + LevelName, 1);
            PlayerPrefs.SetInt("Star1" + LevelName, 0);
            PlayerPrefs.SetInt("Star2" + LevelName, 0);
        }
        else if (time > 25)
        {
            PanelFailed.gameObject.SetActive(true);
            PanelFinish.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Star0" + LevelName, 0);
            PlayerPrefs.SetInt("Star1" + LevelName, 0);
            PlayerPrefs.SetInt("Star2" + LevelName, 0);
        }
        
    }

    private void Update()
    {
        if (var)
        {
            time = time + Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            TimerP.text = "Time " + min + ":" + sec + ":" + msec;
            TimerFi.text = "Time " + min + ":" + sec + ":" + msec;
            TimerFa.text = "Time " + min + ":" + sec + ":" + msec;
        }
    }

}
