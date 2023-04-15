using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Meter : MonoBehaviour
{
    float maxHp = 1000;
    float currentHp;
    float damage = 1.0f;
    //Slider������
    public Slider slider;

    void Start()
    {
        //Slider�𖞃^���ɂ���B
        slider.value = 0f;
        //���݂�HP���ő�HP�Ɠ����ɁB
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

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + slider.value);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            damage *= 1.01f;
            currentHp = currentHp + damage;
            Debug.Log("After currentHp : " + currentHp);

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
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
