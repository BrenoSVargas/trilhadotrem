using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceManager : MonoBehaviour
{
    private int chanceCount = 5;

    private static ChanceManager _instance;
    public static ChanceManager Instance

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

    public void ChanceSub()
    {
        chanceCount--;
        UIManager.instance.UpdateChanceCount(chanceCount);
        if (chanceCount <= 0)
        {
            StopAllCoroutines();
            UIManager.instance.GameOver();
        }

    }
}
