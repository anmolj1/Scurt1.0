using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log(collision2D.transform.name);
        if (collision2D.transform.name == "BulletToRight(Clone)"){
            Destroy(gameObject);
        
        var hit = collision2D.gameObject;
        var Health = hit.GetComponent<Health>();
        
        if (Health  != null){
            Health.TakeDamage(10);
            
        
        }

    }
}
}

