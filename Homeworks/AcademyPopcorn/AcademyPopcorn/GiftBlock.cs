using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft) : base(topLeft)
        {
            this.body = new char[,] { { 'G' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.ProduceObjects();
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gifts = new List<GameObject>();
            if (this.IsDestroyed)
            {
                gifts.Add( new Gift(this.TopLeft));
            }
            return gifts;
        }
    }
}
