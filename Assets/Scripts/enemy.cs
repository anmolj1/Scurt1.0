using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.name == "Player"){
        
        var hit = collision2D.gameObject;
        var Health = hit.GetComponent<Health>();
        
        if (Health  != null)
        {
            Health.TakeDamage(10);

         }
    

        if (PlayerController.singleton.myAnimator.GetBool("atack")){

            Destroy(gameObject);
        }
            
        }

    }
}

