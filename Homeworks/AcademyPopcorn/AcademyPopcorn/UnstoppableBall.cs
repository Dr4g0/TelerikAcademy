using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        
        public new const string CollisionGroupString = "unstoppBall";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed) 
            : base(topLeft, speed)
        {
            this.body = new char[,] { { '*' } };
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "unpassBlock" || otherCollisionGroupString == "racket"
                || otherCollisionGroupString == "indestructibleBlock"||otherCollisionGroupString=="block";
            
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            List<string> collisionMagicStrings = collisionData.hitObjectsCollisionGroupStrings;
            foreach (var magicString in collisionMagicStrings)
            {
                if (magicString == "unpassBlock" || magicString == "racket" || magicString == "indestructibleBlock")
                {
                    base.RespondToCollision(collisionData);
                }
            }
        }
        
    }
}
