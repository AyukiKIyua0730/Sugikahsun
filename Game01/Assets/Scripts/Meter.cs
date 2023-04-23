using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Meter : MonoBehaviour
{
    float maxHp = 5000;
    float currentHp;
    float damage = 1.0f;
    //Slider‚ğ“ü‚ê‚é
    public Slider slider;
    public GameObject damageObject;
    public GameObject triggerObject;
    public GameObject startObject;
    private bool damagetrigger;

    public GameObject SceneChange;

    Startscript startscript;
    void Start()
    {
        damagetrigger = false;

        


        //Slider‚ğ–ƒ^ƒ“‚É‚·‚éB
        slider.value = 0f;
        //Œ»İ‚ÌHP‚ğÅ‘åHP‚Æ“¯‚¶‚ÉB
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

                //Å‘åHP‚É‚¨‚¯‚éŒ»İ‚ÌHP‚ğSlider‚É”½‰fB
                //int“¯m‚ÌŠ„‚èZ‚Í¬”“_ˆÈ‰º‚Í0‚É‚È‚é‚Ì‚ÅA
                //(float)‚ğ‚Â‚¯‚Äfloat‚Ì•Ï”‚Æ‚µ‚ÄU•‘‚í‚¹‚éB
                slider.value = (float)currentHp / (float)maxHp; ;
                //Debug.Log("slider.value : " + slider.value);
                if ((slider.value >= 1) || (slider.value <= -1))
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
}
