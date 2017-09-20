using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    

    public GameObject sphere, floor, basket, target,pointarget,scorepoint,board,buttom;
    public int score =0; //score是所得分數

    Rigidbody rig;
    Ray ray;
    Quaternion basketTarget;    


    float dist;
    float a;    //按下的時間紀錄
    int touch; //touch是球在地板彈的次數
    int fever = 0; //連進加分
    bool into = false;
    bool isturn = false;//籃框使否轉向

    RaycastHit[] hits;
    // Use this for initialization

    public void DoItagain()
    {       
        SceneManager.LoadScene("baseket");
    }

    public void GoBackMenu()
    {
        SceneManager.LoadScene("Main");
    }

    void Start()
    {
        //Time.timeScale = 0;        
        rig = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        Time.timeScale = 1;
        into = false;

        rig.isKinematic = false;//rigbody啟用

        a = a + Time.deltaTime;

        target.transform.position = new Vector3(sphere.transform.position.x * 4, 7, 5);        

        if (target.transform.position.x >= 5)
        {
            target.transform.position = new Vector3(5,7,5);
        }
        else if (target.transform.position.x <= -5)
        {
            target.transform.position = new Vector3(-5, 7, 5);
        }

        if (a < 0.5 && a > 0.12f)
        {
            basket.transform.position = sphere.transform.position;           
        }
                
    }

    private void OnMouseUp()
    {               
        basket.transform.rotation = Quaternion.LookRotation(target.transform.position - basket.transform.position);
        if (a < 0.5 && a>0.12f)
        {
            rig.AddRelativeForce(Vector3.forward * 900);

            a = 0;
        }
        else
        {
            basket.transform.position = new Vector3(0, -3, 0.44f);
            a = 0;
        }
    }


    void spot()
    {
        basketTarget = Quaternion.LookRotation(pointarget.transform.position - basket.transform.position);
        basket.transform.rotation = basketTarget;
        basket.transform.Translate(new Vector3(0, 0, 3f * Time.deltaTime), Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pointscore")
        {
            score++;
            into = true;
        }
        else
        {
            into = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (touch == 1)
        {
            rig.isKinematic = true;    //rigbody停用
            basket.transform.position = new Vector3(0, -3, 0.44f);
            touch = 0;
        }

        if (collision.other.tag == "floor")
        {
            if (into == true )
            {
                if(touch == 2)
                {
                    fever++;
                }
                                
            }
            else
            {
                fever = 0;
                board.transform.position = new Vector3(0, 1.2f, 19);
            }
            touch++;            
            //print("touch"+touch);
        }
        //print(fever);
    }

    

    void Update()
    {
        dist = Vector3.Distance(basket.transform.position,pointarget.transform.position);
        basket.transform.rotation = Quaternion.LookRotation(pointarget.transform.position - basket.transform.position);

        if (dist <= 20 && dist > 5)
        {
            spot();
        }
        else if(dist <= 5)
        {
            basket.transform.Translate(new Vector3(0, 0, 0), Space.Self);
        }
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction, Color.red);
        hits = Physics.RaycastAll(ray.origin, ray.direction, 50);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.tag == "wall")
            {
                sphere.transform.position = hits[i].point;
            }

        }

        if (fever >= 1)
        {
            if (isturn == false)
            {
                board.transform.Translate(new Vector3(-5*Time.deltaTime,0,0),Space.Self);
                if (board.transform.position.x >= 6)
                {
                    
                    isturn = true;
                }
            }

            if (isturn == true)
            {
                board.transform.Translate(new Vector3(3 * Time.deltaTime, 0, 0), Space.Self);
                if (board.transform.position.x < -6)
                {
                    
                    isturn = false;
                }
            }
        }
        //|| Time.timeScale == 0
        if (basket.transform.position.y < -5 )
        {
            rig.isKinematic = true;    //rigbody停用
            basket.transform.position = new Vector3(0, -3, 0.44f);
            touch = 0;
            
            if (into == false)
            {                
                fever = 0;
                board.transform.position = new Vector3(0,1.2f,19);
            }
            
        }       

    }


}
