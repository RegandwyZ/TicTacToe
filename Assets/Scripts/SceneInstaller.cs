using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameBoard _board;

    public override void InstallBindings()
    {
        InitBoard();
        InitGameBoardController();
    }

    private void InitGameBoardController()
    {
        Container.Bind<GameBoardController>().AsSingle().WithArguments(
            _board.InitializeUpdateBoard(),
            _board.InitializeCheckWinCondition(),
            _board.GetGameBoardView()
        );
    }

    private void InitBoard()
    {
        _board.InitializeBoard();
    }
}