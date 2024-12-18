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

    public void RestartGameButton()
    {
        _restart.gameObject.SetActive(true);
    }

    public void ShowVictoryText(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Cross:
                _crossWinning.gameObject.SetActive(true);
                break;
            
            case PlayerType.Zero:
                _zeroWinning.gameObject.SetActive(true);
                break;
        }
    }
    
    
    public PlayerType ChangePlayer(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Zero:
                _crossSprite.SetActive(true);
                _zeroSprite.SetActive(false);
                break;
            
            case PlayerType.Cross:
                _crossSprite.SetActive(false);
                _zeroSprite.SetActive(true);
                break;
        }

        return type == PlayerType.Cross ? PlayerType.Zero : PlayerType.Cross;
    }
}