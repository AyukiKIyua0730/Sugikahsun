using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startscript : MonoBehaviour
{
    public GameObject Readygo;
    public bool ready;
    private Text ready_text;
    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        StartCoroutine("Corou1");
        
    }

    // Update is called once per frame
    void Update()
    {
        ready_text = Readygo.GetComponent<Text>();
    }

    IEnumerator Corou1() //�R���[�`���֐��̖��O
        {
        //�R���[�`���̓��e
        
        Debug.Log("�X�^�[�g");
            yield return new WaitForSeconds(2.0f);
        ready_text.text = "GO!!!";
        yield return new WaitForSeconds(3.0f);
        Readygo.gameObject.SetActive(false);
        ready = true;
        Debug.Log("�X�^�[�g����5�b��");
        }
}
