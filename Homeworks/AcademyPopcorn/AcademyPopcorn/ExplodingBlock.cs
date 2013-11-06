using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {

        public int LifeTime { get; set; }
        

        public ExplodingBlock(MatrixCoords topLeft, int lifeTime)
            : base(topLeft)
        {
            this.LifeTime = lifeTime;
            this.body = new char[,] { { '&' } };
        }

        //public override bool CanCollideWith(string otherCollisionGroupString)
        //{
        //    return otherCollisionGroupString == "ball" || otherCollisionGroupString == "unstoppBall";
        //}

        //public override void RespondToCollision(CollisionData collisionData)
        //{
        //    this.IsDestroyed = true;

        //}

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<ExplodingTrail> explodeObjects = new List<ExplodingTrail>();
            if (this.IsDestroyed)
            {
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col - 1), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + 1), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col - 1), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col + 1), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col - 1), this.LifeTime));
                explodeObjects.Add(new ExplodingTrail(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col + 1), this.LifeTime));
                
            }
            return explodeObjects;
        }

        
    }
}
