using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingTrail : MovingObject
    {
        public int LifeTime { get; set; }

        public ExplodingTrail(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] { { '.' } },new MatrixCoords(0,0))
        {
            this.LifeTime = lifeTime;
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            if (this.LifeTime == 0)
            {
                this.IsDestroyed = true;
            }
            this.LifeTime--;
        }
    }
}
