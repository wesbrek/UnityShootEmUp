using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

        public void LoadScene(int a)
    {
        SceneManager.LoadScene(a);
    }
}
