using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;


public class ballScript : MonoBehaviour {

	public Rigidbody2D rb; 
	public Rigidbody2D hook; 
	private bool isPressed = false; 
	public float releaseTime = .15f; 
	public float maxDragDistance = 2f; 
	public GameObject nextBall;
	public GameObject enemy, enemy1; 
	public Image image; 
	public int ballCounter; 
	void Update () {
		if (isPressed) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); 

			if (Vector3.Distance (mousePos, hook.position) > maxDragDistance) {
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance; 
			}

			else 
			rb.position = mousePos; 
		}
	}

	void OnMouseDown () {
		isPressed = true; 
		rb.isKinematic = true; 
	}

	void OnMouseUp () {
		isPressed = false; 
		rb.isKinematic = false; 
		StartCoroutine(Release()); 

	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);
		GetComponent<SpringJoint2D>().enabled = false; 
		this.enabled = false; 

		yield return new WaitForSeconds (2f); 
		Destroy (image.gameObject); // UI for lives 


		if (nextBall != null) {
			nextBall.SetActive (true);
		/*} else if (enemy != null || enemy1 != null){ // works when both objects are not destroyed 
			SceneManager.LoadScene ("mainLevel1"); 
			//SceneManager.LoadScene ("mainLevel 2");
		} else if( GameObject.Find("Enemy") != null ) {//null && enemy1 != null ){
			SceneManager.LoadScene ("mainLevel2"); // (SceneManager.GetActiveScene ().buildIndex);  
			//SceneManager.LoadScene ("mainLevel 2"); */ 
		}  else {
			EnemyScript.enemyAlive = 0; 
			SceneManager.LoadScene ("mainLevel1"); // (SceneManager.GetActiveScene ().buildIndex);  
			//SceneManager.LoadScene ("mainLevel 2");
		}
		/*if (GameObject.Find ("Enemy") != null) {
			Debug.Log ("get one");
		} else {
			Debug.Log ("not there");
		}*/ 
	}

}
