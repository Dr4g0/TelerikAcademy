using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        private bool hasShot = false;

        public ShootingRacket(MatrixCoords topLeft, int width) : base(topLeft, width)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Bullet> shots = new List<Bullet>();
            if (this.hasShot)
            {
                shots.Add(new Bullet(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + 3)));
                this.hasShot = false;
            }
            return shots;
        }

        public void Shooting()
        {
            this.hasShot=true;
        }

    }
}
