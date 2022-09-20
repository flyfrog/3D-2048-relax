using Pool;
using SaveAndLoad;
using SO;
using UI;
using UnityEngine;
using Zenject;

namespace GameManagmentControllers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MaterialListForCubes _materialListForCubes;
        [SerializeField] private GameSettingsSO _gameSettings;
        [SerializeField] private CubePoolSettingsSO _cubePoolSettings;
        [SerializeField] private FXPoolSettingsSO _fxPoolSettings;
        [SerializeField] private ExplosionSettingsSO _explosionSettingsSo;
        [SerializeField] private DuckSettingsSO _duckSettingsSo; 

        public override void InstallBindings()
        {
            //Scriptable object
            Container.Bind<MaterialListForCubes>().FromInstance(_materialListForCubes).AsSingle().NonLazy();
            Container.Bind<GameSettingsSO>().FromInstance(_gameSettings).AsSingle().NonLazy();
            Container.Bind<CubePoolSettingsSO>().FromInstance(_cubePoolSettings).AsSingle().NonLazy();
            Container.Bind<FXPoolSettingsSO>().FromInstance(_fxPoolSettings).AsSingle().NonLazy();
            Container.Bind<ExplosionSettingsSO>().FromInstance(_explosionSettingsSo).AsSingle().NonLazy();
            Container.Bind<DuckSettingsSO>().FromInstance(_duckSettingsSo).AsSingle().NonLazy();

            //Normal class
            Container.Bind<CubeSpawner>().AsSingle().NonLazy();
            Container.Bind<PoolFX>().AsSingle().NonLazy();
            Container.Bind<PoolCubes>().AsSingle().NonLazy();
            Container.Bind<FXSpawner>().AsSingle().NonLazy();
            Container.Bind<RestartController>().AsSingle().NonLazy();
            Container.Bind<HeaderUIController>().AsSingle().NonLazy();
            Container.Bind<MenuUIController>().AsSingle().NonLazy();
            Container.Bind<ScoreController>().AsSingle().NonLazy();
            Container.Bind<PauseController>().AsSingle().NonLazy();
            Container.Bind<GameOverController>().AsSingle().NonLazy();
            Container.Bind<SaveManager>().AsSingle().NonLazy();
            Container.Bind<LoadManager>().AsSingle().NonLazy();
            Container.Bind<ExitController>().AsSingle().NonLazy();
       
            

            //intarface realize
            Container.BindInterfacesAndSelfTo<InputConroller>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RedZoneCubeDetector>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InitGameController>().AsSingle().NonLazy();
        }
    }
}