using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeStart;
    public Question[] questions;
    private Question currentQuestion;
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
    }




    private void Update()
    {
        if (UIManager.instance.indexScene == 1)
        {
            timeStart += Time.deltaTime;
        }
    }

    void GetQuestion()
    {
        //if(timeStart>= )

    }
}
