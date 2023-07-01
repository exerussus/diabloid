
using Cinemachine;

namespace Resources.Scripts.Data
{
    public class GameData
    {
        public PlayerData PlayerData;
        public EnemiesData EnemiesData;
        public CinemachineVirtualCamera CinemachineVirtualCamera;
        public int CurrentWorld { get;}
        public WorldData[] WorldsData;
    }
}