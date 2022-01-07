using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSlot : MonoBehaviour
{
    public Building_Info buildingInfo;
    public Image buildingImage;

    public void UpdateBuilding()
    {
        int currentLevel = PlayerPrefs.GetInt("Building" + transform.GetSiblingIndex());
        if (currentLevel == 0) return;

        buildingImage.sprite = buildingInfo.sprites[currentLevel - 1];

    }

    public void UpdateBuilding(int level)
    {
        if (level == 0) return;

        buildingImage.sprite = buildingInfo.sprites[level - 1];

    }
}
