
 public class GameBoardController
 {
     private readonly GameBoardView _boardView;
     
     public UpdateBoard UpdateBoard { get; }
     public CheckWinCondition CheckWinCondition { get; }

     public GameBoardController(UpdateBoard updateBoard, CheckWinCondition checkWinCondition, GameBoardView boardView )
     {
         UpdateBoard = updateBoard;
         CheckWinCondition = checkWinCondition;
         _boardView = boardView;
     }
     
     public void Restart()
     {
         _boardView.RestartGame();
     }

     public void ShowCrossVictory()
     {
         _boardView.ShowCrossVictoryText();
     }

     public void ShowZeroVictory()
     {
         _boardView.ShowZeroVictoryText();
     }

     public bool ChangePlayer(bool value)
     {
        return _boardView.ChangeCrossZero(value);
     }
 }
