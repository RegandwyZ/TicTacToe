using UnityEngine;


public class InputSystem : MonoBehaviour
{
    [SerializeField] private GameBoard _board;

    private GameBoardController _boardController;
    private Camera _mainCamera;

    private bool _isCross;
    private bool _isGameOver;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    public void SetController(GameBoardController boardController)
    {
        _boardController = boardController;
    }
    
    private void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                var cell = hit.collider.GetComponent<Cell>();
                if (cell == null || cell.IsOccupied) return;
                if (_isGameOver) return;

                _isCross = _boardController.ChangePlayer(_isCross);

                cell.SetOccupied();
                switch (_isCross)
                {
                    case true:
                        cell.SetType(CellType.Cross);
                        break;

                    case false:
                        cell.SetType(CellType.Zero);
                        break;
                }

                var position = cell.transform.position;
                position.y = 0.2f;

                var x = (int)position.x;
                var z = (int)position.z;
                _boardController.UpdateBoard.UpdateCells(x, z, cell);

                if (_boardController.CheckWinCondition.CheckWin(cell.Type))
                {
                    _isGameOver = true;
                    switch (cell.Type)
                    {
                        case CellType.Cross:
                            _boardController.ShowCrossVictory();
                            break;

                        case CellType.Zero:
                            _boardController.ShowZeroVictory();
                            break;
                    }

                    _boardController.Restart();
                }
            }
        }
    }
}