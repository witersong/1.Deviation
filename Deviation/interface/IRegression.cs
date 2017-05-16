
using System;
using System.Collections.Generic;

namespace Deviation
{
    interface IRegression
    {
        void getSum(List<Tuple<int,int>> list);
        void getAverage(List<Tuple<int, int>> a);
        void BRegress(List<Tuple<int, int>>  a);
        void BReader(List<Tuple<int, int>> a);

        void getPow(List<Tuple<int, int>> input);

        
    }
}
