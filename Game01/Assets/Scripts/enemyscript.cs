using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyscript : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;


    [SerializeField]
    private Sprite[] ofsImage;

    private Sprite spriteMae;
    public GameObject[] PrefabCube= new GameObject[5];

    private GameObject[] obj = new GameObject[5];

    public GameObject[] PrefabCube2 = new GameObject[5];
    private GameObject[] obj2 = new GameObject[5];
    private GameObject[] slider = new GameObject[5];
    private float x = -8.0f;
    private float y = 1.0f;
    private float y2 = 4.0f;

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
    private Animator[] anim3= new Animator[5];

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

            Vector2 v2 = new Vector2(x, y2);
            obj2[i] = Instantiate(PrefabCube2[i], v2, Quaternion.identity);
            anim3[i] = obj2[i].GetComponent<Animator>();

            slider[i] = child.GetComponent<Transform>().transform.GetChild(0).gameObject;
            slider2[i] = slider[i].GetComponent<Slider>();
            x += 4.5f;
            Imagechange(i);

        }
        x = -6.0f;
        y = -2.0f;
        y2 = 1.0f;
        i = 3;
        for (i = 3; i < 5; i++)
        {
            maxHP[i] = 40f;
            currentHp[i] = 40f;
            Vector2 v = new Vector2(x, y);
            obj[i] = Instantiate(PrefabCube[i], v, Quaternion.identity);
            child = obj[i].GetComponent<Transform>().transform.GetChild(0).gameObject;
            
            Vector2 v2 = new Vector2(x, y2);
            obj2[i] = Instantiate(PrefabCube2[i], v2, Quaternion.identity);
            anim3[i] = obj2[i].GetComponent<Animator>();

            slider[i] = child.GetComponent<Transform>().transform.GetChild(0).gameObject;
            slider2[i] = slider[i].GetComponent<Slider>();
            x += 4.5f;
            Imagechange(i);
        }
        anim3[0].SetBool("FPbool", false);
        anim3[1].SetBool("FPbool", false);
        anim3[2].SetBool("FPbool", false);
        anim3[3].SetBool("FPbool", false);
        anim3[4].SetBool("FPbool", false);

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("add", false);
        anim2.SetBool("count", false);
       



    }

    public void damage(float damage)
    {
        anim3[0].SetBool("FPbool", true);
        anim3[1].SetBool("FPbool", true);
        anim3[2].SetBool("FPbool", true);
        anim3[3].SetBool("FPbool", true);
        anim3[4].SetBool("FPbool", true);
        i = 0;
        for (i = 0; i < 5; i++)
        {

            currentHp[i] = currentHp[i] - damage;
           



            slider2[i].value = currentHp[i] / maxHP[i];
            
            if(currentHp[i]<=0)
            {
                //Vector3 x2 = obj[i].transform.position;
                //Vector3 pos = new Vector3(-20, obj[i].transform.position.y, 0);
                //obj[i].transform.position = Vector3.MoveTowards(x2, pos, 3.5f * Time.deltaTime);
                Imagechange(i);
                c++;
                b += 3.0f;
                Scorenum.score_num+=1;
                soundManager.PlaySe(clip);
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

        Invoke(nameof(DelayMethod), 2.1f);

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


    public void Imagechange(int number)
    {
        
       
   
        spriteMae = ofsImage[Random.Range(0, 5)];
        
        obj[number].gameObject.GetComponent<SpriteRenderer>().sprite = spriteMae;
    }

    void DelayMethod()
    {
        anim3[0].SetBool("FPbool", false);
        anim3[1].SetBool("FPbool", false);
        anim3[2].SetBool("FPbool", false);
        anim3[3].SetBool("FPbool", false);
        anim3[4].SetBool("FPbool", false);
        
    }
}
