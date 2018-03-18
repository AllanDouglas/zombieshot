using Zombieshot.Engine;
using UnityEngine;
using System;

namespace Zombieshot.Game
{

    public class TargetBehaviour : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        protected int speed = -50;
        [SerializeField]
        protected int range;
        [SerializeField]
        protected float loadTime = .5f;
        #endregion

        public float RestTime
        {
            get;
            private set;
        }

        public IWeapon Weapon
        {
            get;
            private set;
        }

        public bool CanShot
        {
            get;
            private set;
        }

        private void Start()
        {
            this.Weapon = new BasicWeapon(Mathf.Abs(this.speed), 1, range, loadTime);
        }

        // Update is called once per frame
        void Update()
        {
            this.Rotate();
            this.RestWeapon();
        }

        private void RestWeapon()
        {
            if (!this.CanShot)
            {
                if (this.RestTime < this.Weapon.ReloadTime)
                {
                    this.RestTime += Time.deltaTime;
                    return;
                }

                this.RestTime = 0;
                this.CanShot = true;
            }
        }

        public IPoint<Vector2> Shot(int tweak = 1)
        {

            if (!this.CanShot) throw new System.Exception("weapon is resting");

            this.CanShot = false;

            int angle = (int)transform.eulerAngles.z;

            return new VectorPoint(
                new Vector2(
                   Mathf.Cos(angle * Mathf.Deg2Rad) * tweak,
                   Mathf.Sin(angle * Mathf.Deg2Rad) * tweak
                )
            );

        }


        private void Rotate()
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }

    }
}