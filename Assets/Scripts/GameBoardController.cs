public class GameBoardController
 {
     private readonly GameBoardView _boardView;
     private readonly UpdateBoard _updateBoard;
     private readonly CheckWinCondition _checkWinCondition;
     
     private PlayerType _currentPlayer;
     private bool _isGameOver;

     
     public GameBoardController(UpdateBoard updateBoard, CheckWinCondition checkWinCondition, GameBoardView boardView )
     {
         _updateBoard = updateBoard;
         _checkWinCondition = checkWinCondition;
         _boardView = boardView;
         
         _currentPlayer = PlayerType.Cross;
     }
     
     
     private PlayerType ChangePlayer(PlayerType type)
     {
         return _boardView.ChangePlayer(type);
     }

     public void ClickLogic(Cell cell)
     {
         if (cell == null || cell.IsOccupied) return;
         if (_isGameOver) return;
                
         cell.SetOccupied();
         switch (_currentPlayer)
         {
             case PlayerType.Cross:
                 cell.SetType(CellType.Cross);
                 break;

             case PlayerType.Zero:
                 cell.SetType(CellType.Zero);
                 break;
         }

         _currentPlayer = ChangePlayer(_currentPlayer);
                
         var position = cell.transform.position;
         position.y = 0.2f;

         var x = (int)position.x;
         var z = (int)position.z;
         _updateBoard.UpdateCells(x, z, cell);

         CheckEndGame(cell);
     }

     private void CheckEndGame(Cell cell)
     {
         if (_checkWinCondition.CheckWin(cell.Type))
         {
             _isGameOver = true;
             switch (cell.Type)
             {
                 case CellType.Cross:
                     _boardView.ShowVictoryText(PlayerType.Cross);
                     break;

                 case CellType.Zero:
                     _boardView.ShowVictoryText(PlayerType.Zero);
                     break;
             }

             _boardView.RestartGameButton();
         }
     }
 }
