 public class CheckWinCondition
 {
     private readonly int _width;
     private readonly int _height;
     
     private readonly Cell[,] _cells;
     
     
     public CheckWinCondition(int width, int height, Cell[,] cells)
     {
         _width = width;
         _height = height;
         _cells = cells;
     }
     
     private readonly (int, int)[] _directions = 
     {
         (1, 0), 
         (0, 1), 
         (1, 1), 
         (1, -1) 
     };

     public bool CheckWin(CellType cellType)
     {
         for (var x = 0; x < _width; x++)
         {
             for (var y = 0; y < _height; y++)
             {
                 foreach (var (dx, dy) in _directions)
                 {
                     if (CheckLine(cellType, x, y, dx, dy, 5))
                         return true;
                 }
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
