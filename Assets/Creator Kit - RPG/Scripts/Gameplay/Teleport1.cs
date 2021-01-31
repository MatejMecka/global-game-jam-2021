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

	    void OnCollisionEnter2D(Collision2D collision)
	    {
	        Debug.Log("Exec");
			SceneManager.LoadScene("Scene 2", LoadSceneMode.Single);
	    }

	}
