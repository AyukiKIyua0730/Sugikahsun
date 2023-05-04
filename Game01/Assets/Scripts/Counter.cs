using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Scorenum
{
    public static int score_num = 0;

}




public class Counter : MonoBehaviour
{
    


    public GameObject score_object;
    public GameObject time_object;
   
    public GameObject SceneChange;

   
    public float countdown = 60.0f;
   

    public GameObject startObject;
    Startscript startscript;
    public GameObject resultObject;
    GameManager s1;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        s1 = this.GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        startscript = startObject.GetComponent<Startscript>();
        anim = startscript.Readygo.GetComponent<Animator>();
       
        if (startscript.ready != false)
        {
            
            Text time_text = time_object.GetComponent<Text>();
            Text score_text = score_object.GetComponent<Text>();
            score_text.text = "Score:" + Scorenum.score_num;

            countdown -= Time.deltaTime;

            time_text.text = countdown.ToString("f1") + "秒";

            //countdownが0以下になったとき
            if (countdown <= 0)
            {
                StartCoroutine("End");
                
                

            }
        }
    }

    IEnumerator End() //コルーチン関数の名前
    {
        Text result_text = resultObject.GetComponent<Text>();
        startscript.ready = false;
        startscript.Readygo.gameObject.SetActive(true);
        startscript.ready_text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);


        result_text.text = "終了！!!";
        yield return new WaitForSeconds(3.0f);
        s1.LoadScene("Result");
        

    }
}
