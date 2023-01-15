using UnityEngine;

namespace Controllers
{
    public interface IControllerComponent
    {
        void IOnPossesPlayer(GameObject newPlayer, PlayerController newPlayerController)
        {
            
        }

        void IOnUnPossesPlayer()
        {
            
        }
    }
}