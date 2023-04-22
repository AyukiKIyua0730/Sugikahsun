using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Meter : MonoBehaviour
{
    float maxHp = 5000;
    float currentHp;
    float damage = 1.0f;
    //Sliderを入れる
    public Slider slider;
    public GameObject damageObject;
    public GameObject triggerObject;
    private bool damagetrigger;

    public GameObject SceneChange;


    void Start()
    {
        damagetrigger = false;

        


        //Sliderを満タンにする。
        slider.value = 0f;
        //現在のHPを最大HPと同じに。
        currentHp = 0;
        //Debug.Log("Start currentHp : " + currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        enemyscript d1 = damageObject.GetComponent<enemyscript>();
        Transform tTransform = triggerObject.transform;
        Vector2 v = tTransform.position;
        GameManager s1 = this.GetComponent<GameManager>();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            damage *= 1.001f;
            currentHp = currentHp - damage;
        if (damagetrigger == false)
        {

            if (currentHp <= -2500.0f)
            {
                    v = new Vector2(9f, -3.5f);
                    tTransform.position = v;
                    d1.damage(10f);
                damagetrigger = true;
            }
        }
            //Debug.Log("After currentHp : " + currentHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp; ;
            //Debug.Log("slider.value : " + slider.value);
            if ((slider.value >= 1)|| (slider.value <= -1))
            {
                s1.LoadScene("Result");
               
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            damage *= 1.001f;
            currentHp = currentHp + damage;
        if (damagetrigger == true)
        {
            if (currentHp >= 2500.0f)
            {

                    v = new Vector2(5f, -3.5f);
                    tTransform.position = v;
                    d1.damage(10f);
                damagetrigger = false;
            }
        }
            //Debug.Log("After currentHp : " + currentHp);

            
            slider.value = (float)currentHp / (float)maxHp; 
            //Debug.Log("slider.value : " + slider.value);
            if ((slider.value >= 1) || (slider.value <= -1))
            {
                s1.LoadScene("Result");
               
            }
        }
        else
        {
            
                if(currentHp<=0)
                {
                    if (damage > 1.0f)
                    {
                    damage *= 0.99f;
                    }
                    currentHp = currentHp + damage;
                    

                    
                }
                else if(currentHp >= 0)
                {
                if (damage > 1.0f)
                {
                    damage *= 0.99f;
                }
                currentHp = currentHp - damage;
                    

                    
                }

                
                slider.value = (float)currentHp / (float)maxHp; 
                
            //}
           
        }
    }
}
