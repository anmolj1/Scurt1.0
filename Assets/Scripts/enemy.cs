﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D collision2D)
    {
       if (collision2D.transform.name == "BulletToRight(Clone)" || collision2D.transform.name == "BulletToLeft(Clone)"){
                   Destroy(gameObject);
                   ScoreScript.scoreValue += 10;}

        if (collision2D.transform.name == "Player"){
        
        var hit = collision2D.gameObject;
        var Health = hit.GetComponent<Health>();
        
        if (Health  != null){
            Health.TakeDamage(10);
            
        
        }

    }
}
}


