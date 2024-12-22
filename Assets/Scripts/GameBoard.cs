using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private GameBoardView _boardView;
    [SerializeField] private GameObject _cellPrefab;
    
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    
    private Cell[,] _cells;

    public void InitializeBoard()
    {
        InitializeArray();
    }
    
    public GameBoardView GetGameBoardView()
    {
        return _boardView;
    }
    
    private void InitializeArray()
    {
        _cells = new Cell[_width, _height];
    }

    public void GenerateGrid()
    {
        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                var position = new Vector3(x, 0.1f,y); 
                Instantiate(_cellPrefab, position, Quaternion.identity);
            }
        }
    }
    
    public UpdateBoard InitializeUpdateBoard()
    {
        return new UpdateBoard(_width, _height, _cells);
    }
    
    public CheckWinCondition InitializeCheckWinCondition()
    {
        return new CheckWinCondition(_width, _height, _cells);
    }

   
}
