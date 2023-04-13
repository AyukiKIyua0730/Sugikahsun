using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public GameObject score_object;
    public GameObject time_object;
   
    public GameObject SceneChange;

   
    public float countdown = 18.0f;
    public int score_num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager s1 = this.GetComponent<GameManager>();
        Text time_text = time_object.GetComponent<Text>();
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "Score:" + score_num;

        countdown -= Time.deltaTime;

        time_text.text = countdown.ToString("f1") + "•b";

        //countdown‚ª0ˆÈ‰º‚É‚È‚Á‚½‚Æ‚«
        if (countdown <= 0)
        {
            s1.LoadScene("Result");
            time_text.text = "ŽžŠÔ‚É‚È‚è‚Ü‚µ‚½I";
        }
    }
}
