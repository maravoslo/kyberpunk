using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingStars : MonoBehaviour
{
    [SerializeField] private GameObject Star0;
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private string LevelName;

    //variabila sa retina doar cel mai bun highscore
    public void Start(){
        //Debug.Log("Aici");

        if(PlayerPrefs.GetInt("Star0" + LevelName, 0) == 1)
        {
            //Debug.Log("Star0");
            Star0.gameObject.SetActive(true);
        }
        else Star0.gameObject.SetActive(false);

        if(PlayerPrefs.GetInt("Star1" + LevelName, 0) == 1)
        {
            //Debug.Log("Star1");
            Star1.gameObject.SetActive(true);
        }
        else Star1.gameObject.SetActive(false);
        if(PlayerPrefs.GetInt("Star2" + LevelName, 0) == 1)
        {
            //Debug.Log("Star2");
            Star2.gameObject.SetActive(true);
        }
        else Star2.gameObject.SetActive(false);
    }

}
