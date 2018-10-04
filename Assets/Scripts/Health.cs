using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {

	public Slider myhealthBar;


	public const int maxHealth = 100;	

	public int currentHealth = maxHealth;
	
	public void start(){
		myhealthBar.value = maxHealth;
	}

	void update(){
		
	}
	public void TakeDamage(int amount){
    	currentHealth -= amount;
    	myhealthBar.value = currentHealth;
    	if (currentHealth <= 0){
        currentHealth = 0;
        SceneManager.LoadScene("Menu");
        
    	}
	}
	
}
