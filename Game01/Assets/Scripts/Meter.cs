using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Meter : MonoBehaviour
{
    float maxHp = 1000;
    float currentHp;
    float damage = 1.0f;
    //Slider‚ð“ü‚ê‚é
    public Slider slider;

    void Start()
    {
        //Slider‚ð–žƒ^ƒ“‚É‚·‚éB
        slider.value = 0f;
        //Œ»Ý‚ÌHP‚ðÅ‘åHP‚Æ“¯‚¶‚ÉB
        currentHp = 0;
        Debug.Log("Start currentHp : " + currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            damage *= 1.01f;
            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            //Å‘åHP‚É‚¨‚¯‚éŒ»Ý‚ÌHP‚ðSlider‚É”½‰fB
            //int“¯Žm‚ÌŠ„‚èŽZ‚Í¬”“_ˆÈ‰º‚Í0‚É‚È‚é‚Ì‚ÅA
            //(float)‚ð‚Â‚¯‚Äfloat‚Ì•Ï”‚Æ‚µ‚ÄU•‘‚í‚¹‚éB
            slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + slider.value);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            damage *= 1.01f;
            currentHp = currentHp + damage;
            Debug.Log("After currentHp : " + currentHp);

            //Å‘åHP‚É‚¨‚¯‚éŒ»Ý‚ÌHP‚ðSlider‚É”½‰fB
            //int“¯Žm‚ÌŠ„‚èŽZ‚Í¬”“_ˆÈ‰º‚Í0‚É‚È‚é‚Ì‚ÅA
            //(float)‚ð‚Â‚¯‚Äfloat‚Ì•Ï”‚Æ‚µ‚ÄU•‘‚í‚¹‚éB
            slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + slider.value);
        }
        else
        {
            if(damage >1.0f)
            {
                damage *= 0.09f;
            }
           
        }
    }
}
