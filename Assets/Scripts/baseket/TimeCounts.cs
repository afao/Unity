using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeCounts : MonoBehaviour
{
    AddForce add;
    
    public Image blood;
    public Text mytext,ans;
    public GameObject button,ask;
    public GameObject basket;
    public float n;    
    int bestscore;
    bool cor = false;
    
    float nt, countnt;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        add = basket.GetComponent<AddForce>();
        
    }

    void swap(float a, float b)
    {
        float temp = a;
        a = b;
        b = temp;
    }

    /*void Order()
    {
        for (int i = 0; i <= 4; i++)
        {
            for (int j = 0; j <= 4 - i; j++)
            {
                if (sort[j] >= sort[j + 1])
                {
                    swap(sort[j], sort[j + 1]);
                }

            }

        }

    }
    */
    public void answer()
    {
        if (ans.text == add.score.ToString())
        {        
            button.SetActive(true);
            cor = true;
        }
		else {
			button.SetActive (false);
			ans.text = "";
		}
    }

    void Update()
    {
        nt = nt + Time.deltaTime;
        countnt = (int)(n - nt);
        blood.fillAmount = (n - nt - 1) / n;
        mytext.text = countnt.ToString();
        //print(mybutton.IsActive());
        
        if ((float)countnt < 0f)
        {
            Time.timeScale = 0;
            mytext.text = 0.ToString();           
            if (add.score > bestscore)
            {
                bestscore = add.score;
                PlayerPrefs.SetInt("bestscore", add.score);                
            }
            basket.SetActive(false);
            
            if (cor == false)
            {
                ask.SetActive(true);
            }
            else
            {
                ask.SetActive(false);
            }
            
        }

        

    }    

}

