using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class flyAway : MonoBehaviour {
    public GameObject sheild;
    public string scenetoload;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player" && sheild.GetComponent<shieldHealth>().hp == 0) 
        {
            SceneManager.LoadScene(scenetoload);        }
    }
}
