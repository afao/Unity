using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class maintouch : MonoBehaviour {
    public Button bask, sre, end;
    public Image logo;
	// Use this for initialization
	void Start () {
        Button basketball = bask.GetComponent<Button>();
        Button score = sre.GetComponent<Button>();
        Button gameove = end.GetComponent<Button>();
        basketball.onClick.AddListener(basketgame);
        score.onClick.AddListener(number);
        gameove.onClick.AddListener(over);

	}
	void basketgame()
    {
        SceneManager.LoadScene("baseket");
    }
    void number()
    {
        SceneManager.LoadScene("highscore");
    }
    void over()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
