using CodeBase.Camera;
using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        
        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => _curtain.Hide();

        private void OnLoaded()
        {
            InitCanvas();
            InitBulletPool();
            GameObject player = InitPlayer();
            InitEnemySpawner();
            
            CameraFollow(player);
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitBulletPool()
        {
            _gameFactory.CreateBulletPool();
        }

        private void InitEnemySpawner()
        {
            _gameFactory.CreateEnemySpawner();
        }
        
        private void InitCanvas()
        {
            _gameFactory.CreateCanvas();
        }

        private GameObject InitPlayer()
        {
            GameObject player = _gameFactory.CreatePlayer();
            return player;
        }

        private void CameraFollow(GameObject player) => 
            UnityEngine.Camera.main.GetComponent<CameraFollow>().Follow(player);
    }
}