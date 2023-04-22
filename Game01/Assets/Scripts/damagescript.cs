using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damagescript : MonoBehaviour
{
    private float[] maxHP= new float[5];
    private float[] currentHp= new float[5];

    int i = 0;

    private Slider[] slider= new Slider[5];

    
   
    // Start is called before the first frame update
    void Start()
    {
        for(i=1;i<5;i++)
        {
            
            maxHP[i] = 20f;
            currentHp[i] = 20f;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(float damage)
    {
        i = 0;
        for (i = 1; i < 5; i++)
        {
            currentHp[i] = currentHp[i] - damage;
            Debug.Log("After currentHp : " + currentHp[i]);

         
            slider[i].value = currentHp[i] / maxHP[i];
            Debug.Log("slider.value : " + slider[i].value);
        }
       
    }
}
