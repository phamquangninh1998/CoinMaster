using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuilding : MonoBehaviour
{
    public int index;
    public int currentLevel;
    public int currentPrice;
    public Building_Info buidingInfo;
    public Image currentLevelImage;
    public Image nextLevelImage;
    public Text currentUpgradePrice;
    public Image arrow;
    public Button buyButton;
    public Transform stars;

    private void Start()
    {
        index = transform.GetSiblingIndex();
        LoadCurrentState();
    }

    private void LoadCurrentState()
    {
        currentLevel = PlayerPrefs.GetInt("Building" + index);

        LoadDataBaseOnCurrentLevel();

    }

    public void Upgrade()
    {
        if (currentLevel == 4) return;

        currentPrice = buidingInfo.updatePrice[currentLevel];
        if (currentPrice > PlayerData.instance.coin) return;
        else
        {
            PlayerData.instance.ConsumeCoin(currentPrice);
            PlayerData.instance.AddStar(1);
        }


        currentLevel++;

        BuildingArea.instance.UpdateArea(index, currentLevel);

        LoadDataBaseOnCurrentLevel();

        PlayerPrefs.SetInt("Building" + index, currentLevel);
    }

    public void LoadDataBaseOnCurrentLevel()
    {

        LoadStar();

        if (currentLevel == 0)
        {
            currentLevelImage.sprite = buidingInfo.sprites[0];
            nextLevelImage.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
            currentUpgradePrice.text = "" + buidingInfo.updatePrice[0];
            return;
        }


        if (currentLevel == 4)
        {
            currentLevelImage.sprite = buidingInfo.sprites[3];
            nextLevelImage.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
            currentUpgradePrice.text = "Max";
            buyButton.gameObject.SetActive(false);

        }
        else
        {

            nextLevelImage.gameObject.SetActive(true);
            arrow.gameObject.SetActive(true);

            currentLevelImage.sprite = buidingInfo.sprites[currentLevel - 1];
            nextLevelImage.sprite = buidingInfo.sprites[currentLevel];
            currentUpgradePrice.text = "" + buidingInfo.updatePrice[currentLevel];
        }
    }

    private void LoadStar()
    {
        for (int i = 0; i < 4; i++)
        {
            stars.GetChild(i).gameObject.SetActive(false);

        }
        for (int i = 0; i < currentLevel; i++)
        {
            stars.GetChild(i).gameObject.SetActive(true);
        }
    }
}
