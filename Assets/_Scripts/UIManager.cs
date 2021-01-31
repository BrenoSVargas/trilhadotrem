using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    private Button _playGame, _exitGame, _home, _okbtn;
    private Text _chanceCountTxt;
    [SerializeField]
    private Image[] correctImg, wrongImg;

    private int indexScene;

    public int IndexScene { get => indexScene; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Load;
    }

    void Load(Scene scene, LoadSceneMode mode)
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _playGame = GameObject.Find("PlayBtn").GetComponent<Button>();
            _exitGame = GameObject.Find("ExitBtn").GetComponent<Button>();

            _playGame.onClick.AddListener(PlayGame);
            _exitGame.onClick.AddListener(ExitGame);

        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _home = GameObject.Find("Home").GetComponent<Button>();
            _okbtn = GameObject.Find("OkBtn").GetComponent<Button>();

            _home.onClick.AddListener(Home);
            _okbtn.onClick.AddListener(OkBtn);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            _home = GameObject.Find("Home").GetComponent<Button>();
            _chanceCountTxt = GameObject.Find("ChanceText").GetComponent<Text>();
            correctImg[0] = GameObject.Find("Correct0").GetComponent<Image>();
            correctImg[1] = GameObject.Find("Correct1").GetComponent<Image>();
            wrongImg[0] = GameObject.Find("Wrong0").GetComponent<Image>();
            wrongImg[1] = GameObject.Find("Wrong1").GetComponent<Image>();

            _home.onClick.AddListener(Home);
            _chanceCountTxt.text = 5.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            _exitGame = GameObject.Find("ExitBtn").GetComponent<Button>();
            _okbtn = GameObject.Find("OkBtn").GetComponent<Button>();
            _home = GameObject.Find("Close").GetComponent<Button>();


            _exitGame.onClick.AddListener(ExitGame);
            _okbtn.onClick.AddListener(OkBtn);
            _home.onClick.AddListener(ExitGame);
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            _exitGame = GameObject.Find("ExitBtn").GetComponent<Button>();
            _okbtn = GameObject.Find("OkBtn").GetComponent<Button>();
            _home = GameObject.Find("Close").GetComponent<Button>();

            _exitGame.onClick.AddListener(ExitGame);
            _okbtn.onClick.AddListener(OkBtn);
            _home.onClick.AddListener(ExitGame);
        }



    }

    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void Home()
    {
        SceneManager.LoadScene(0);
    }
    void OkBtn()
    {
        SceneManager.LoadScene(2);
    }

    public void UpdateChanceCount(int chances)
    {
        _chanceCountTxt.text = chances.ToString();

    }

    public void Wrong(int number)
    {
        wrongImg[number].enabled = true;
    }

    public void Correct(int number)
    {
        correctImg[number].enabled = true;
    }

    public void DesableCorrection()
    {
        for (int i = 0; i < 2; i++)
        {
            correctImg[i].enabled = false;
            wrongImg[i].enabled = false;
        }
    }

    public void Win()
    {
        SceneManager.LoadScene(3);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(4);
    }
}