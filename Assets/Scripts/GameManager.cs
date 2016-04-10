﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//Water and speed
	public int water = 0;
    private int speed = 0;

    //GUI
    public Font newFont;
	private int fontSize;
	bool isMenuOn = false;

	public Texture2D backgroundTexture;
	public Texture2D hydroLevelTexture;
	public Texture2D topWaterTexture;
	public LeakingWater scoreScript;
    private bool showScore = false;

    public GameObject[] finishSpots;
    public int currentObjectiveIndex;

    float x; //-146;
	float height= 865; //(full tank);//195f;+670


	// Use this for initialization
	void Start () {
        currentObjectiveIndex = Random.Range(0, finishSpots.Length);

        for (int i = 0; i < finishSpots.Length; i++)
        {
			if(i != currentObjectiveIndex)
				finishSpots[i].SetActive(false);
		}
    }

	// Update is called once per frame
	void Update () {
		//x = scoreScript.currentWaterAmount+822f;

		if(Input.GetKeyDown(KeyCode.F1) && showScore == false){
			isMenuOn = !isMenuOn;
		}
		if(isMenuOn == true){
			if(Input.GetKeyDown(KeyCode.Space)){
                //Application.LoadLevel(0);
				SceneManager.LoadScene(0);
			}
			if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape)){
				Application.Quit();
			}
		}
		if(scoreScript.gameFinished){
			isMenuOn = true;
			showScore = true;

		}
		x = -scoreScript.currentWaterAmount-103; // NEW

	}
	void OnGUI(){
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		nStyle.normal.textColor = new Color(0,100,255);

		if(isMenuOn == true){
			nStyle.normal.background = backgroundTexture;
			nStyle.fontSize = 60;
			GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Menu",nStyle);
			nStyle.normal.background = null;
			nStyle.fontSize = 26;
			GUI.Label (new Rect (0, Screen.height-30, 200, 200), "Press SPACE to restart: " , nStyle);
			GUI.Label (new Rect (Screen.width-200, 10, 200, 200), "Press Q to quit: " , nStyle);

			if(showScore){
				GUI.TextField (new Rect (Screen.width/2 - 40, Screen.height/2 - 40, 200, 200), "GAME OVER!", nStyle);
				GUI.TextField (new Rect (Screen.width/2 - 40, Screen.height/2, 200, 200), "Score: " + scoreScript.score, nStyle);
			}

	}
		if(isMenuOn == false){
			nStyle.normal.textColor = new Color(0,100,255);
			nStyle.fontSize = 26;
			//GUI.TextField (new Rect (Screen.width-200, 10, 200, 200), "Water: "+water+ " l.", nStyle);
			nStyle.normal.textColor = new Color(255,255,0);
			nStyle.fontSize = 25;

			nStyle.normal.background = hydroLevelTexture;
			GUI.TextField (new Rect (Screen.width-200, Screen.height - 200, 200, 200), "", nStyle);
			nStyle.normal.background = topWaterTexture;
			GUI.TextField (new Rect (Screen.width-195, Screen.height + 5, 190, x), "", nStyle); //heigth 195

			nStyle.normal.background = null;
		}
	}
}
