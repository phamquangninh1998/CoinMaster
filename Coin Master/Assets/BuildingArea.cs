using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    public static BuildingArea instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UpdateArea();
    }

    public void UpdateArea()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<BuildingSlot>().UpdateBuilding();
        }
    }

    public void UpdateArea(int buildingIndex, int level)
    {

        transform.GetChild(buildingIndex).GetComponent<BuildingSlot>().UpdateBuilding(level);

    }
}
