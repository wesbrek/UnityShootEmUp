using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerPrefText : MonoBehaviour
{

    public string name;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetFloat("posX", 0);
         PlayerPrefs.SetFloat("posY", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(name) != 0){
            GetComponent<Text>().text = PlayerPrefs.GetInt(name)+"";
        }else if(PlayerPrefs.GetFloat(name) != 0){
            GetComponent<Text>().text = PlayerPrefs.GetFloat(name)+"";
        }
       
        
    }
}
