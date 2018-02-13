using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class GameControllerService : GameManager
    {
        
        [Inject]
        public GameControllerService(
            IInputManager inputManager
            ) : base(inputManager)
        {            
        }
        
    }
}