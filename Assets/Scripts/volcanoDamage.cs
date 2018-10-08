using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volcanoDamage : MonoBehaviour {

public ParticleSystem part;


void OnParticleCollision(GameObject other)
    {
       

        if (other.transform.name == "Player"){
        
        var hit = other.gameObject;
        var Health = hit.GetComponent<Health>();
        
        if (Health  != null){
            Health.TakeDamage(10);
            
        
        }

    }
}
}
