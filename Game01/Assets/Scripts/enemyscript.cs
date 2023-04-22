using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyscript : MonoBehaviour
{
    public GameObject[] PrefabCube= new GameObject[5];

    private GameObject[] obj = new GameObject[5];
    private GameObject[] slider = new GameObject[5];
    private float x = -8.0f;
    private float y = 1.0f;

    private float[] maxHP = new float[5];
    private float[] currentHp = new float[5];

    private Slider[] slider2 = new Slider[5];
    int i = 0;

    private GameObject child;

    public GameObject CounterObject;
    public GameObject CounterObject2;
    public GameObject AddtimeObject;
    private Animator anim;
    private Animator anim2;

    private Text addtime_text;
    Counter counter;

    int c = 0;
    
    float b = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        addtime_text = AddtimeObject.GetComponent<Text>();
        anim = AddtimeObject.GetComponent<Animator>();
        anim2 = CounterObject2.GetComponent<Animator>();
        counter = CounterObject.GetComponent<Counter>();
        for (i = 0; i < 3; i++)
        {
            maxHP[i] = 20f;
            currentHp[i] = 20f;
            Vector2 v = new Vector2(x, y);
            obj[i] = Instantiate(PrefabCube[i], v, Quaternion.identity);
            child= obj[i].GetComponent<Transform>().transform.GetChild(0).gameObject;
            slider[i] = child.GetComponent<Transform>().transform.GetChild(0).gameObject;
            slider2[i] = slider[i].GetComponent<Slider>();
            x += 4.5f;
            

        }
        x = -6.0f;
        y = -2.0f;
        i = 3;
        for (i = 3; i < 5; i++)
        {
            maxHP[i] = 40f;
            currentHp[i] = 40f;
            Vector2 v = new Vector2(x, y);
            obj[i] = Instantiate(PrefabCube[i], v, Quaternion.identity);
            child = obj[i].GetComponent<Transform>().transform.GetChild(0).gameObject;
            slider[i] = child.GetComponent<Transform>().transform.GetChild(0).gameObject;
            slider2[i] = slider[i].GetComponent<Slider>();
            x += 4.5f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("add", false);
        anim2.SetBool("count", false);
    }

    public void damage(float damage)
    {
        
        i = 0;
        for (i = 0; i < 5; i++)
        {

            currentHp[i] = currentHp[i] - damage;
           



            slider2[i].value = currentHp[i] / maxHP[i];
            
            if(currentHp[i]<=0)
            {
                c++;
                b += 3.0f;
                counter.score_num+=1;
                anim2.SetBool("count", true);
                delete(i);
            }
        }

        if(c>=1)
        {
            addtime_text.text = "+"+b.ToString("f1");
            anim.SetBool("add", true);
            
            counter.countdown += b;
            b = 0.0f;
            c = 0;
        }

    }

    public void delete(int a)
    {
        
        
        //å≥ÇÃHP*0.5Å`1.5f
        float r = Random.Range(1.0f, 1.5f);
        //float dHP = (float)counter.score_num * r;
        maxHP[a] = maxHP[a] * r;
        currentHp[a] = maxHP[a];
        slider2[a].value = currentHp[a] / maxHP[a];
        Debug.Log("maxHP[a]" + maxHP[a]);
    }





}
