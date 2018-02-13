using Zombieshot.Engine;
using UnityEngine;
using Zenject;
namespace Zombieshot.Game
{
    public class TouchControllerBehaviour : MonoBehaviour
    {
        [Inject]
        private IInputManager inputHandler;
        
    }
}