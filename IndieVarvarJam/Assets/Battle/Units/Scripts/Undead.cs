using UnityEngine;

namespace Battle.Units
{
    public class Undead : Unit
    {
        

        public override void ChangeHealth(int value)
        {
            base.ChangeHealth(value);
        }

        public override void Death()
        {
            base.Death();
        }
    }
}