using UnityEngine;

namespace Zombieshot.Game
{
    [CreateAssetMenu]
    public class LevelsSettings : ScriptableObject
    {
        public LevelPayload[] levels;
    }

    [System.Serializable]
    public sealed class WavePayload
    {
        [Tooltip("Amount enimies will be spawned")]
        public int amountEnimies;
        public EnemyBehaviour[] enimies;
    }

    [System.Serializable]
    public sealed class LevelPayload
    {
        public int id;
        public WavePayload[] waves;

    }

}