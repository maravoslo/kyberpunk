using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuButtons : MonoBehaviour
{
    public void Level1()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      Time.timeScale = 1f;
    }
    public void Level2()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
      Time.timeScale = 1f;
    }
    public void Level3()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
      Time.timeScale = 1f;
    }
    public void Level4()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
      Time.timeScale = 1f;
    }

    public void BackButton()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
      Time.timeScale = 1f;
    }
}
