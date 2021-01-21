using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> imgPlayers;
    private Button boy1, girl1, boy2, girl2;
    private Image selectedPlayerImg;
    // Start is called before the first frame update
    private void Awake()
    {
        boy1 = GameObject.Find("Menino1").GetComponent<Button>();
        girl1 = GameObject.Find("Menina1").GetComponent<Button>();
        boy2 = GameObject.Find("Menino2").GetComponent<Button>();
        girl2 = GameObject.Find("Menina2").GetComponent<Button>();
        selectedPlayerImg = GameObject.Find("PlayerImage").GetComponent<Image>();

        boy1.onClick.AddListener(ChangePlayer);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangePlayer()
    {
        selectedPlayerImg.sprite = imgPlayers[0];

    }
}
