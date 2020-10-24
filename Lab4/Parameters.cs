using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    class ParametersForFirst
    {
        public Matrix   res, matr1, matr2;
        public int[]    mulV, mulH;
        public int      startI, endI, m2, m1;

        public ParametersForFirst(Matrix res, Matrix matr1, Matrix matr2, int[] mulV, int[] mulH, int startI, int endI, int m2, int m1)
        {
            this.res    = res;
            this.matr1  = matr1;
            this.matr2  = matr2;
            this.mulV   = mulV;
            this.mulH   = mulH;
            this.startI = startI;
            this.endI   = endI;
            this.m2     = m2;
            this.m1     = m1;
        }
    }

    class ParametersForSecond
    {
        public Matrix   matr;
        public int[]    mul;
        public int      startI, endI, endJ;

        public ParametersForSecond(Matrix matr, int[] mul, int startI, int endI, int endJ)
        {
            this.matr   = matr;
            this.mul    = mul;
            this.startI = startI;
            this.endI   = endI;
            this.endJ   = endJ;
        }
    }
}
