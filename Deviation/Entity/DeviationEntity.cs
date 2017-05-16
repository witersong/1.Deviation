using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviation.Entity
{
  public  class DeviationEntity
    {
        private int numSeq;
        private int numX;
        private double numDeviation;

        public DeviationEntity(int numSeq, int numX, double numDeviation)
        {
            this.numSeq = numSeq;
            this.numX = numX;
            this.numDeviation = numDeviation;
        }

        public DeviationEntity()
        {
        }

        public int NumSeq
        {
            get
            {
                return numSeq;
            }

            set
            {
                numSeq = value;
            }
        }

        public int NumX
        {
            get
            {
                return numX;
            }

            set
            {
                numX = value;
            }
        }

        public double NumDeviation
        {
            get
            {
                return numDeviation;
            }

            set
            {
                numDeviation = value;
            }
        }
    }
}
