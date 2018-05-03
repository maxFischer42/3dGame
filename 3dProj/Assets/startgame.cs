using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startgame : MonoBehaviour {

    public string level;
	// Use this for initialization
    

    public void changelevel()
    {
        SceneManager.LoadScene(level);
    }
}
