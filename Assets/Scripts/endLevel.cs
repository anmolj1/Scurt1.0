using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour {

void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.name == "Player"){
        
        SceneManager.LoadScene("Menu");

    }
}
}