using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultscript : MonoBehaviour
{
    public Text result_text;
    // Start is called before the first frame update
    void Start()
    {
        result_text.text = "Score:" + Scorenum.score_num;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
