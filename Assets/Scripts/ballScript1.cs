using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;


public class ballScript1 : MonoBehaviour {

	public Rigidbody2D rb; 
	public Rigidbody2D hook; 
	private bool isPressed = false; 
	public float releaseTime = .15f; 
	public float maxDragDistance = 2f; 
	public GameObject nextBall; 
	public Image image; 
	public GameObject enemy, enemy1, enemy2, enemy3, enemy4; 
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
		Destroy (image.gameObject);
		//Destroy (gameObject); 
		//ballCounter--; 
		//nextBall.SetActive (true);

		if (nextBall != null) /*&& (enemy != null || enemy1 != null || enemy2 != null ||  enemy3 != null || enemy4 != null))*/ {
			nextBall.SetActive (true);
		} else {
			EnemyScript2.enemyAlive = 0; 
			SceneManager.LoadScene ("mainLevel2"); // (SceneManager.GetActiveScene ().buildIndex);  
			//SceneManager.LoadScene ("mainLevel 2");*/ 
		} 
	}

}
