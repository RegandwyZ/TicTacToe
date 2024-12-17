using UnityEngine;

public class BootStrapGame : MonoBehaviour
{
    [SerializeField] private GameBoard _board;
    [SerializeField] private InputSystem _inputSystem;
    
    private void Awake()
    {
        _board.InitializeArray();
        _board.GenerateGrid();
        
        _inputSystem.SetController(InitBoardController());
    }

    private GameBoardController InitBoardController()
    {
        return new GameBoardController(_board.InitializeUpdateBoard(),
            _board.InitializeCheckWinCondition(), _board.GetGameBoardView());
    }
}