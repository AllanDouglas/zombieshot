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


        public IPoint<int> GetLookAngle()
        {
            return new BasicPoint(
                Mathf.RoundToInt(transform.eulerAngles.z)
            );

        }

        private void Rotate()
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }

    }
}