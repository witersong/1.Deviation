using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deviation.Entity
{
    public class ProgramData
    {
        private Int64 valx;
        private Int64 valy;
        private Int64 ncnt;
        private double valX2;
        private double valY2;
        private double valXavg;
        private double valYavg;
        private double valRXY;
        private double valBi;
        private double valBo;

        public long Valx
        {
            get
            {
                return valx;
            }

            set
            {
                valx = value;
            }
        }

        public long Valy
        {
            get
            {
                return valy;
            }

            set
            {
                valy = value;
            }
        }

        public long Ncnt
        {
            get
            {
                return ncnt;
            }

            set
            {
                ncnt = value;
            }
        }

        public double ValX2
        {
            get
            {
                return valX2;
            }

            set
            {
                valX2 = value;
            }
        }

        public double ValY2
        {
            get
            {
                return valY2;
            }

            set
            {
                valY2 = value;
            }
        }

        public double ValXavg
        {
            get
            {
                return valXavg;
            }

            set
            {
                valXavg = value;
            }
        }

        public double ValYavg
        {
            get
            {
                return valYavg;
            }

            set
            {
                valYavg = value;
            }
        }

        public double ValRXY
        {
            get
            {
                return valRXY;
            }

            set
            {
                valRXY = value;
            }
        }

        public double ValBi
        {
            get
            {
                return valBi;
            }

            set
            {
                valBi = value;
            }
        }

        public double ValBo
        {
            get
            {
                return valBo;
            }

            set
            {
                valBo = value;
            }
        }
    }
    public class ProgramDataList
    {
        private List<ProgramData> listProgramData;

        public List<ProgramData> ListProgramData
        {
            get
            {
                return listProgramData;
            }

            set
            {
                listProgramData = value;
            }
        }
    }
    
}
