using UnityEngine;

namespace Battle.Controller
{
    public delegate void ActionHappened();

    public class EndTurnButton : MonoBehaviour
    {
        public event ActionHappened TurnEnded;

        public void EndTurn()
        {
            TurnEnded?.Invoke();
        }
    }
}