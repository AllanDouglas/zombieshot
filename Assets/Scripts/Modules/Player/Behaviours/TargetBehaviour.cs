using Zombieshot.Engine;
using UnityEngine;

namespace Zombieshot.Game
{

    public class TargetBehaviour : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        protected int speed = -50;
        [SerializeField]
        protected int range;
        #endregion

        public IWeapon Weapon
        {
            get;
            private set;
        }

        private void Start()
        {
            this.Weapon = new BasicWeapon(Mathf.Abs(this.speed), 1);
        }

        // Update is called once per frame
        void Update()
        {
            this.Rotate();
        }


        public IPoint<Vector2> GetLookPosition()
        {

            int angle = (int)transform.eulerAngles.z;

            Vector2 pos = new Vector2(
                   Mathf.Cos(angle * Mathf.Deg2Rad),
                   Mathf.Sin(angle * Mathf.Deg2Rad)
            );

            return new VectorPoint(pos);            

        }

        private void Rotate()
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }

    }
}