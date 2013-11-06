using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public int TimeLife { get; set; }
        private List<TrailObject> meteoTrail;
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int timeLife=3)
            : base(topLeft, speed)
        {
            this.TimeLife = timeLife;
        }

        public override void Update()
        {
            base.Update();
            meteoTrail = new List<TrailObject>();
            meteoTrail.Add(new TrailObject(this.TopLeft,this.TimeLife));
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return this.meteoTrail;
        }
        
    }
}
