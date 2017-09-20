using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HightScore : MonoBehaviour {

	public Button back;
    public Text NumberOne;
    public int[] sort = new int[6];
    int NOne;

	void Start () {
		Button Bk =back.GetComponent<Button>();
		Bk.onClick.AddListener(BackMain);
	}
	void BackMain(){
		SceneManager.LoadScene ("Main");
	}

    // Update is called once per frame
    void Update ()
    {
        NOne = PlayerPrefs.GetInt("bestscore");
		NumberOne.text = NOne.ToString ();
		
        
	}
}
