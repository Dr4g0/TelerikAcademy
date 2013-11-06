using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft) 
            : base(topLeft, new char[,]{{'G'}}, new MatrixCoords(1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var collisionItem in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionItem=="racket")
                {
                    this.IsDestroyed = true;
                }
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<ShootingRacket> shootingRacket = new List<ShootingRacket>();
            if (this.IsDestroyed)
            {
                shootingRacket.Add(new ShootingRacket(new MatrixCoords(this.TopLeft.Row+1,this.TopLeft.Col), 7));
            }
            return shootingRacket;
        }
    }
}
