using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsOccupied { get; set; }
    
    public CellType Type { get; set; }
}


public enum CellType
{
    Cross, 
    Zero   
}
