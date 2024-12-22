using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameBoard _board;

    public override void InstallBindings()
    {
        InitBoard();

        Container.Bind<UpdateBoard>().FromInstance(_board.InitializeUpdateBoard()).AsSingle();
        Container.Bind<CheckWinCondition>().FromInstance(_board.InitializeCheckWinCondition()).AsSingle();
        Container.Bind<GameBoardView>().FromInstance(_board.GetGameBoardView()).AsSingle();
        
        Container.Bind<GameBoardController>().AsSingle();
    }
    

    private void InitBoard()
    {
        _board.InitializeBoard();
    }
}