using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviation.Entity
{
    public class DeivationList
    {
        private List<DeviationEntity> listDeviationEntity;
        private double DeviationPow;
        private double sumDeviation;
        private int sumX;
        private double avgX;
        public List<DeviationEntity> ListDeviationEntity
        {
            get
            {
                return listDeviationEntity;
            }

            set
            {
                listDeviationEntity = value;
            }
        }

        public double DeviationPow1
        {
            get
            {
                return DeviationPow;
            }

            set
            {
                DeviationPow = value;
            }
        }

        public double SumDeviation
        {
            get
            {
                return sumDeviation;
            }

            set
            {
                sumDeviation = value;
            }
        }

        public int SumX
        {
            get
            {
                return sumX;
            }

            set
            {
                sumX = value;
            }
        }

        public double AvgX
        {
            get
            {
                return avgX;
            }

            set
            {
                avgX = value;
            }
        }
    }
}
