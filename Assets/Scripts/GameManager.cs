using UnityEngine;

public class GameManager : MonoBehaviour
{
     [SerializeField] private GameBoard _board;
     
     [SerializeField] private int _width;
     [SerializeField] private int _height;

     private Cell[,] _cells;
    
     private void Start()
     {
          _board.GenerateGrid(_width, _height);
          _cells = new Cell[_width, _height];
     }
     
     public void UpdateCells(int x, int y, Cell cell)
     {
          if (x >= 0 && x < _width && y >= 0 && y < _height)
          {
               _cells[x, y] = cell;
          }
     }
     
     
     public bool CheckWinCondition(CellType cellType)
     {
          for (var x = 0; x < _width; x++)
          {
               for (var y = 0; y < _height; y++)
               {
                    if (CheckLine(cellType, x, y, 1, 0, 5))
                         return true;
                    
                    if (CheckLine(cellType, x, y, 0, 1, 5))
                         return true;
                    
                    if (CheckLine(cellType, x, y, 1, 1, 5))
                         return true;
                    
                    if (CheckLine(cellType, x, y, 1, -1, 5))
                         return true;
               }
          }
          return false;
     }

    private bool CheckLine(CellType cellType, int startX, int startY, int dx, int dy, int count)
     {
          for (var i = 0; i < count; i++)
          {
               var x = startX + i * dx;
               var y = startY + i * dy;

               if (x < 0 || x >= _width || y < 0 || y >= _height || _cells[x, y] == null || _cells[x, y].Type != cellType)
               {
                    return false;
               }
          }
          return true;
     }
}


