using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private GameBoardController _boardController;
    private Camera _mainCamera;
    
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
                _boardController.ClickLogic(cell);
            }
        }
    }
}