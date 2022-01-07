using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuildingInfo", order = 1)]
public class Building_Info : ScriptableObject
{
    public int id;
    public Sprite[] sprites;
    public int[] updatePrice;
}