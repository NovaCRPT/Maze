using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public TextMeshProUGUI GameOverText;
    public int maxSeconds;
    private float startTime;
    
    // Start is called before the first frame update
    void Start()
    {   
        GameOverText.enabled=false;
        startTime = Time.time;
            ResumeGame();
        
    }

    // Update is called once per frame
    void Update()
    {   if (Input.GetKeyDown(KeyCode.Return)) {
			RestartGame();
		}
    
     /*
        if (Input.GetKeyDown(KeyCode.A)) {
			PauseGame();
		}   if (Input.GetKeyDown(KeyCode.B)) {
			ResumeGame();
		}
     */
		float t = Time.time - startTime;
        string minutes = ((int) t /60).ToString();
        int seconds =  (int)(t % 60);
        int secondsElapsed = maxSeconds - seconds;
        if(secondsElapsed>=0)
        TimerText.text = secondsElapsed.ToString();
        else{ 
        this.GameOver();
        }
        
    }

	 void RestartGame() {
		this.ResumeGame();
        Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
       
	}

	// Update is called once per frame
	void GameOver()
    {
      GameOverText.enabled=true; 
       TimerText.enabled=false; 
        PauseGame();
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
