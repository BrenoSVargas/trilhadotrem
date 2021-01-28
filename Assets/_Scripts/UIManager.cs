using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    private Button _playGame, _exitGame, _home, _okbtn;
    public int indexScene;

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

        indexScene = SceneManager.GetActiveScene().buildIndex;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}