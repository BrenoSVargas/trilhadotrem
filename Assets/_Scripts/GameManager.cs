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
    private bool hitTheAnswer = false;
    private bool waitForAnswer = false;
    private int questionNumber = 0;


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
        if (UIManager.instance.IndexScene == 2)
        {
            timeStart = 0;
            questionNumber = 0;
            hitTheAnswer = false;
            waitForAnswer = false;

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
        if (UIManager.instance.IndexScene == 2)
        {
            timeStart += Time.deltaTime;

            CheckTimeQuestion();
        }
    }

    void CheckTimeQuestion()
    {
        if (timeStart > 19f && questionNumber == 0)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }
        else if (timeStart > 30f && questionNumber == 1)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }
        else if (timeStart > 54f && questionNumber == 2)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }
        else if (timeStart > 65f && questionNumber == 3)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }

        else if (timeStart > 90f && questionNumber == 4)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }

        else if (timeStart > 99.5f && questionNumber == 5)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }

        else if (timeStart > 125f && questionNumber == 6)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }
        else if (timeStart > 138f && questionNumber == 7)
        {
            waitForAnswer = true;
            GetQuestion(questions[questionNumber]);
            questionNumber++;
        }
        else if (timeStart > 165f)
        {
            StopAllCoroutines();
            UIManager.instance.Win();
        }
        else if (hitTheAnswer)
        {
            StopAllCoroutines();
            StartCoroutine(DesableOptions());
            hitTheAnswer = false;

        }



    }

    void GetQuestion(Question question)
    {
        optBtn0.gameObject.SetActive(true);
        optBtn1.gameObject.SetActive(true);

        optTxt0.text = question.option0;
        optTxt1.text = question.option1;

        answer = question.optionIs;
        StartCoroutine(StartQuestion());

    }


    void OptChoose0()
    {
        if (waitForAnswer == true)
        {
            waitForAnswer = false;
            hitTheAnswer = true;
            if (answer == true)
            {
                UIManager.instance.Correct(0);
                Instantiate(questions[questionNumber - 1].sound);
            }
            else
            {
                UIManager.instance.Wrong(0);
                ChanceManager.Instance.ChanceSub();
            }
        }
    }

    void OptChoose1()
    {
        if (waitForAnswer == true)
        {
            waitForAnswer = false;
            hitTheAnswer = true;
            if (answer == false)
            {
                UIManager.instance.Correct(1);
            }
            else
            {
                UIManager.instance.Wrong(1);
                ChanceManager.Instance.ChanceSub();
            }

        }
    }

    IEnumerator StartQuestion()
    {

        yield return new WaitForSeconds(5);
        if (waitForAnswer)
        {
            ChanceManager.Instance.ChanceSub();
            hitTheAnswer = true;
            waitForAnswer = false;
        }

    }

    IEnumerator DesableOptions()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.DesableCorrection();

        yield return new WaitForSeconds(0.2f);
        optBtn0.gameObject.SetActive(false);
        optBtn1.gameObject.SetActive(false);
    }
}
