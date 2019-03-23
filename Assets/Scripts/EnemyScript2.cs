using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class EnemyScript2 : MonoBehaviour {

	public float health = 4f; 
	public static int enemyAlive = 0; 

	// Use this for initialization

	void Start() {
		enemyAlive++; 
	}
	void OnCollisionEnter2D(Collision2D colInfo) {

		if (colInfo.relativeVelocity.magnitude > health)
			Die (); 
		//SceneManager.LoadScene ("mainLevel2");
	}

	void Die()
	{
		enemyAlive--; 
		if (enemyAlive <= 0)
			//yield return new WaitForSeconds (3f); 
			SceneManager.LoadScene ("mainLevel3");
		//Debug.Log ("level won"); 
		Destroy (gameObject); 
		//gameObject = ;

	}
}