using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsOccupied { get; private set; }
    public CellType Type { get; private set; }
    
    
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _zero;

    private void Awake()
    {
        _cross.SetActive(false);
        _zero.SetActive(false);
    }
    
    public void SetOccupied()
    {
        IsOccupied = true;
    }

    public void SetType(CellType type)
    {
        Type = type;
        
        switch (type)
        {
            case CellType.Cross:
                _cross.SetActive(true);
                break;
            
            case CellType.Zero:
                _zero.SetActive(true);
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}





