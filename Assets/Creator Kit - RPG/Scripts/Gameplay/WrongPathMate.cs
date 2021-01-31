using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	
using UnityEngine.Video;

public class WrongPathMate : MonoBehaviour
{
	float timerZaDaProcitash;
	public float limitZaDaProcitash = 40f;
	private VideoPlayer m_VideoPlayer;	

	void Awake () {
        m_VideoPlayer = GetComponent<VideoPlayer>();
        m_VideoPlayer.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    void OnMovieFinished(VideoPlayer player){
    	Debug.Log("Executed");
    	player.Stop();
    	SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }


    // Update is called once per frame
    /*
    void Update()
    {
        if(timerZaDaProcitash > limitZaDaProcitash){
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    	}
    	timerZaDaProcitash += Time.deltaTime;
    }*/
}
