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
    public GameObject startObject;
    private bool damagetrigger;

    public GameObject SceneChange;

    Startscript startscript;

    GameManager s1;
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
        startscript = startObject.GetComponent<Startscript>();
        if(startscript.ready != false)
        {
            enemyscript d1 = damageObject.GetComponent<enemyscript>();

            Transform tTransform = triggerObject.transform;
            Vector2 v = tTransform.position;
            s1 = this.GetComponent<GameManager>();
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
                if ((slider.value >= 1) || (slider.value <= -1))
                {
                    StartCoroutine("End");
                  //  s1.LoadScene("Result");

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
                    StartCoroutine("End");
                   // s1.LoadScene("Result");

                }
            }
            else
            {

                if (currentHp <= 0)
                {
                    if (damage > 1.0f)
                    {
                        damage *= 0.99f;
                    }
                    currentHp = currentHp + damage;



                }
                else if (currentHp >= 0)
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

    IEnumerator End() //コルーチン関数の名前
    {

        startscript.ready = false;
        startscript.Readygo.gameObject.SetActive(true);
        startscript.ready_text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);


        startscript.ready_text.text = "終了！!!";
        yield return new WaitForSeconds(3.0f);
        s1.LoadScene("Result");


    }
}
