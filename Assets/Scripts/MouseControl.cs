using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseControl : MonoBehaviour
{
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _zero;

    [SerializeField] private GameObject _crossSprite;
    [SerializeField] private GameObject _zeroSprite;

    [SerializeField] private TextMeshProUGUI _crossWinning;
    [SerializeField] private TextMeshProUGUI _zeroWinning;

    [SerializeField] private Button _restart;
   
    private GameManager _gameManager;

    private bool _isCross;
    private bool _isGameOver;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _zeroSprite.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                Cell cell = hit.collider.GetComponent<Cell>(); 
                if (cell != null && !cell.IsOccupied)
                {
                    var position = cell.transform.position;
                    var pos = position;
                    pos.y = 0.2f;
                    
                    if (!_isGameOver)
                    {
                        Instantiate(ChangeCrossZero(), pos, Quaternion.Euler(90, 0, 0));
                    }
                    
                    cell.IsOccupied = true;
                    if (_isCross)
                    {
                        cell.Type = CellType.Cross;
                    }
                    else if (!_isCross)
                    {
                        cell.Type = CellType.Zero;
                    }
                    
                    var x = (int)position.x; 
                    var z = (int)position.z; 
                    _gameManager.UpdateCells(x, z, cell);

                    if (_gameManager.CheckWinCondition(cell.Type))
                    {
                        _isGameOver = true;
                        if(cell.Type == CellType.Cross)
                            _crossWinning.gameObject.SetActive(true);
                        if(cell.Type == CellType.Zero)
                            _zeroWinning.gameObject.SetActive(true);
                        
                        _restart.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    private GameObject ChangeCrossZero()
    {
        if (_isCross)
        {
            _crossSprite.SetActive(true);
            _zeroSprite.SetActive(false);
        }
        else if (!_isCross)
        {
            _crossSprite.SetActive(false);
            _zeroSprite.SetActive(true);
        }
        _isCross = !_isCross;
        
        return _isCross ? _cross : _zero;
    }
    
}
