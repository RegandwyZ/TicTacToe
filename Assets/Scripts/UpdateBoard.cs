public class UpdateBoard 
{
    private readonly int _width;
    private readonly int _height;
    private readonly Cell[,] _cells;

    public UpdateBoard(int width, int height, Cell[,] cells)
    {
        _width = width;
        _height = height;
        _cells = cells;
    }
    
    public void UpdateCells(int x, int y, Cell cell)
    {
        if (x >= 0 && x < _width && y >= 0 && y < _height)
        {
            _cells[x, y] = cell;
        }
    }
}
