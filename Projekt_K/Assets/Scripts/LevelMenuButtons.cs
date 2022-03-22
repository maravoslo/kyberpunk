using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuButtons : MonoBehaviour
{
    public void Level1()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Level2()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void BackButton()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
