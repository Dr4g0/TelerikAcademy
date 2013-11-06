using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        public int LifeTime { get; set; }

        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] {{'.'}})
        {
            this.LifeTime = lifeTime;
        }
        
        public override void Update()
        {
            if (this.LifeTime==1)
            {
                this.IsDestroyed = true;
                return;
            }
            this.LifeTime--;
        }
    }
}
