	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class Teleport1 : MonoBehaviour
	{
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }

	    // Update is called once per frame
	    void Update()
	    {
	        
	    }

	    void OnTriggerEnter(Collision2D collision)
	    {
	        if (collision.gameObject.tag == "Player")
	        {
	        	Debug.Log("Exec");
	            SceneManager.LoadScene("Scene 2", LoadSceneMode.Single);
	        }
	    }

	}
