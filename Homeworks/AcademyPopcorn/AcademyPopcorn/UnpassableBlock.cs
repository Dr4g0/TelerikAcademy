using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassBlock";

        public UnpassableBlock(MatrixCoords topLeft) : base(topLeft)
        {
            this.body=new char[,]{{'@','@','@','@'}};
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
