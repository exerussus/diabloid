
using Cinemachine;
using Resources.Scripts.MonoBehaviours;
using UnityEngine;

namespace Resources.Scripts.Data
{
    public class GameData
    {
        public PlayerData PlayerData;
        public EnemiesData EnemiesData;
        public CinemachineVirtualCamera CinemachineVirtualCamera;
        public int CurrentWorldIndex;
        public WorldData[] WorldsData;
        public GameObject CurrentWorld;
        public WorldInfo CurrentWorldInfo;
    }
}