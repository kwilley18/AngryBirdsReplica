using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using UnityEngine.EventSystems; 


public class gameOverScript : MonoBehaviour {

	Text flashingText; 
	// Use this for initialization
	void Start () {
		/*flashingText = GetComponent<Text> (); 
		StartCoroutine (BlinkText()); */ 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene ("mainLevel1"); 
		}
	}

	//function to blink the text
	/*public IEnumerator BlinkText(){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
			//set the Text's text to blank
//			flashingText.text = "j";
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(.5f);
			//display “I AM FLASHING TEXT” for the next 0.5 seconds
			flashingText.text= "I AM FLASHING TEXT!";
			yield return new WaitForSeconds(.5f);
		}
	}*/ 

}

