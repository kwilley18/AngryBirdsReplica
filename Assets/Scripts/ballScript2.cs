using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;


public class ballScript2 : MonoBehaviour {

	public Rigidbody2D rb; 
	public Rigidbody2D hook; 
	private bool isPressed = false; 
	public float releaseTime = .15f; 
	public float maxDragDistance = 2f; 
	public GameObject nextBall; 
	public Image image; 
	public GameObject enemy, enemy1, enemy2, enemy3, enemy4, enemy5; 
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
		Destroy (image.gameObject); // UI used for lives 

		if (nextBall != null) {
			nextBall.SetActive (true);
		/*} else if (EnemyScript3.enemyAlive > 0){//(enemy != null || enemy1 != null || enemy2 != null ||  enemy3 != null || enemy4 != null || enemy5 != null ){
		SceneManager.LoadScene ("mainLevel3"); // (SceneManager.GetActiveScene ().buildIndex);  */ 
		} else {
			EnemyScript3.enemyAlive = 0; 
			SceneManager.LoadScene ("mainLevel3"); // (SceneManager.GetActiveScene ().buildIndex);  
			//SceneManager.LoadScene ("mainLevel 2");
		}
	}

}
