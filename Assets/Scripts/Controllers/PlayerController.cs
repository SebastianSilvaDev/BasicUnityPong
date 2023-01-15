using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        protected GameObject player;
        
        public GameObject Player => player;

        public void PossesPlayer(GameObject newpPlayer)
        {
            player = newpPlayer;
            IControllerComponent[] controllerComponents = gameObject.GetComponents<IControllerComponent>();
            foreach (var controllerComponent in controllerComponents)
            {
                controllerComponent.IOnPossesPlayer(player, this);
            }
        }

        public void UnPossesPlayer()
        {
            player = null;
            IControllerComponent[] controllerComponents = gameObject.GetComponents<IControllerComponent>();
            foreach (var controllerComponent in controllerComponents)
            {
                controllerComponent.IOnUnPossesPlayer();
            }
        }
    }
}