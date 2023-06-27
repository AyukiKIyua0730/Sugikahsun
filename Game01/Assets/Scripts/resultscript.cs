using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultscript : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioClip clip2;
    public Text result_text;
    public Text result2_text;
    public GameObject Result;
    // Start is called before the first frame update
    void Start()
    {

        result_text.text = "Score:" + Scorenum.score_num;

        if(result.resulttri==-1)
        {
            soundManager.PlaySe(clip);
            result2_text.text = "GameOver" ;
            Result.SetActive(true);
        }
        else
        {
            soundManager.PlaySe(clip2);
            result2_text.text = "TimeUP";

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
