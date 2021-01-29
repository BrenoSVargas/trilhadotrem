using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeStart;
    public Question[] questions;
    private Question currentQuestion;


    private Button optBtn0, optBtn1;
    private Text optTxt0, optTxt1;

    private bool answer;

    //Singleton
    private static GameManager _instance;
    public static GameManager Instance

    {
        get
        {
            if (_instance == null)
                Debug.Log("Error instance GameManger is null.");

            return _instance;
        }
    }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;

        SceneManager.sceneLoaded += Load;
    }



    void Load(Scene scene, LoadSceneMode mode)
    {
        if (UIManager.instance.indexScene == 2)
        {

            optBtn0 = GameObject.Find("BtnOption0").GetComponent<Button>();
            optBtn1 = GameObject.Find("BtnOption1").GetComponent<Button>();

            optBtn0.onClick.AddListener(OptChoose0);
            optBtn1.onClick.AddListener(OptChoose1);

            optTxt0 = GameObject.Find("optText0").GetComponent<Text>();
            optTxt1 = GameObject.Find("optText1").GetComponent<Text>();

            optBtn0.gameObject.SetActive(false);
            optBtn1.gameObject.SetActive(false);
        }

    }




    private void Update()
    {
        if (UIManager.instance.indexScene == 2)
        {
            timeStart += Time.deltaTime;

            CheckTimeQuestion();
        }
    }

    void CheckTimeQuestion()
    {
        if (timeStart < 25f && timeStart > 19f)
        {
            GetQuestion(questions[0]);
        }
        else if (timeStart > 30f && timeStart < 37f)
        {
            GetQuestion(questions[1]);
        }
        else if (timeStart > 54f && timeStart < 62f)
        {
            GetQuestion(questions[2]);
        }
        else if (timeStart > 65f && timeStart < 72f)
        {
            GetQuestion(questions[3]);
        }

        else if (timeStart > 90f && timeStart < 98f)
        {
            GetQuestion(questions[4]);
        }

        else if (timeStart > 99.5f && timeStart < 107f)
        {
            GetQuestion(questions[5]);
        }

        else if (timeStart > 125f && timeStart < 132f)
        {
            GetQuestion(questions[6]);
        }
        else if (timeStart > 138f && timeStart < 143f)
        {
            GetQuestion(questions[7]);
        }
        else
        {
            optBtn0.gameObject.SetActive(false);
            optBtn1.gameObject.SetActive(false);
        }



    }

    void GetQuestion(Question question)
    {
        optBtn0.gameObject.SetActive(true);
        optBtn1.gameObject.SetActive(true);

        optTxt0.text = question.option0;
        optTxt1.text = question.option1;

        answer = question.optionIs;
    }


    void OptChoose0()
    {
        if (answer == true)
        {
            Debug.Log("Acertou");
        }
        else
        {
            Debug.Log("Errou");
        }
    }

    void OptChoose1()
    {
        if (answer == false)
        {
            Debug.Log("Acertou");
        }
        else
        {
            Debug.Log("Errou");
        }
    }
}
