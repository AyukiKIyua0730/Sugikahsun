using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformtree : MonoBehaviour
{

    public float radius = 10f;

    Vector3 initPos;
    float speed =0.5f;
    Vector2 pos;
    bool push = false;
    private float totalTime = 0f;
    void Start()
    {

        
        float phase = speed * Mathf.PI;

        float xPos = radius * Mathf.Cos(phase);
        float yPos = radius * Mathf.Sin(phase);

        pos = new Vector2(xPos, yPos);
        gameObject.transform.position = pos;

        initPos = gameObject.transform.position;
    }
    void Update()
    {
        //totalTime = Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            push = true;
            speed += 0.001f;
            
            float phase = speed* Time.deltaTime * Mathf.PI;
            
            float xPos = radius * Mathf.Cos(phase);
            float yPos = radius * Mathf.Sin(phase);

            pos = new Vector2(xPos, yPos);
            gameObject.transform.position = pos;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            push = true;
            speed -= 0.001f;

            float phase = speed * Time.deltaTime * Mathf.PI;
            float xPos = radius * Mathf.Cos(phase);
            float yPos = radius * Mathf.Sin(phase);
      
            pos = new Vector2(xPos, yPos);
            gameObject.transform.position = pos;
        }
        else
        {
            push = false;
        }
        if (push == false)
        {
            totalTime = 0f;
            if (initPos.x < pos.x)
            {
                Debug.Log("A");
                speed += 0.000333f;
               
                float phase = speed  * Mathf.PI;

                float xPos = radius * Mathf.Cos(phase);
                float yPos = radius * Mathf.Sin(phase);

                pos = new Vector2(xPos, yPos);
                gameObject.transform.position = pos;
            }
            else if (initPos.x > pos.x)
            {
                speed -= 0.000333f;
               
                float phase = speed  * Mathf.PI;

                float xPos = radius * Mathf.Cos(phase);
                float yPos = radius * Mathf.Sin(phase);

                pos = new Vector2(xPos, yPos);
                gameObject.transform.position = pos;
            }
        }


        
        
    }
    /// <Summary>
    /// オブジェクトの位置を計算するメソッドです。
    /// </Summary>
    
}
