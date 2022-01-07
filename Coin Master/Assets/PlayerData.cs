using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int coin;
    public int star;


    public Text coinText;
    public Text starText;


    public static PlayerData instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coin = PlayerPrefs.GetInt("coin");
        star = PlayerPrefs.GetInt("star");
        if (CheckNewPlayer()) coin = 200;
        coinText.text = "" + coin;
        starText.text = "" + star;


    }

    public bool CheckNewPlayer()
    {
        return (coin == 0 && star == 0);
    }

    public void AddStar(int _amount)
    {
        star += _amount;
        starText.text = "" + star;

        UpdateData();

    }
    public void ConsumeCoin(int _amount)
    {
        coin -= _amount;
        coinText.text = "" + coin;

        UpdateData();
    }

    public void AddCoin(int _amount)
    {
        coin += _amount;

        UpdateData();
    }
    public void UpdateData()
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("star", star);

    }

    private void OnApplicationQuit()
    {
        UpdateData();
    }
}
