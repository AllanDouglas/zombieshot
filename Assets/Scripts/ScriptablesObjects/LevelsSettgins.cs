using UnityEditor;
using UnityEngine;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    [CreateAssetMenu]
    public class LevelSettings : ScriptableObject
    {
        public LevelPayload[] levels;
    }

    [System.Serializable]
    public sealed class WavePayload
    {
        public int amount;
        public int enemyLevel;
    }

    [System.Serializable]
    public sealed class LevelPayload
    {
        public int id;
        public WavePayload[] waves;

    }

}