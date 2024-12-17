using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardView : MonoBehaviour
{
    
    [SerializeField] private GameObject _crossSprite;
    [SerializeField] private GameObject _zeroSprite;
    
    
    [SerializeField] private TextMeshProUGUI _crossWinning;
    [SerializeField] private TextMeshProUGUI _zeroWinning;

    [SerializeField] private Button _restart;
    
    
    public void RestartGame()
    {
        _restart.gameObject.SetActive(true);
    }

    public void ShowCrossVictoryText()
    {
        _crossWinning.gameObject.SetActive(true);
    }
    
    public void ShowZeroVictoryText()
    {
        _zeroWinning.gameObject.SetActive(true);
    }
    
    public bool ChangeCrossZero(bool value)
    {
        switch (value)
        {
            case true:
                _crossSprite.SetActive(true);
                _zeroSprite.SetActive(false);
                break;
            
            case false:
                _crossSprite.SetActive(false);
                _zeroSprite.SetActive(true);
                break;
        }

        return !value;
    }
}