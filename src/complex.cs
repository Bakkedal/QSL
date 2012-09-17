/*

Copyright 2012 Dmitri Fedorov.

This file is part of GSLs (GSL#).

GSLs is free software: you can redistribute it and/or modify it under
the terms of the GNU General Public License as published by the Free
Software Foundation, either version 3 of the License, or (at your option)
any later version.

GSLs is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
for more details.

You should have received a copy of the GNU General Public License
along with GSLs.  If not, see <http://www.gnu.org/licenses/>.

*/

using SM=System.Math;

public struct complex {

public double re,im;

public complex(double x) { this.re = x; this.im = 0; }
public complex(double x, double y) { this.re = x; this.im = y; }

public static implicit operator complex(double x){ return new complex(x);}

public static readonly complex I = new complex(0,1);

public static complex operator+(complex a)
   { return a; }
public static complex operator+(complex a, double b)
   { return new complex(a.re+b,a.im); }
public static complex operator+(double a, complex b)
   { return new complex(a+b.re,b.im); }
public static complex operator+(complex a, complex b)
   { return new complex(a.re+b.re, a.im+b.im); }

public static complex operator-(complex a)
   { return new complex(-a.re,-a.im); }
public static complex operator-(complex a, double b)
   { return new complex(a.re-b, a.im); }
public static complex operator-(double a, complex b)
   { return new complex(a-b.re, -b.im); }
public static complex operator-(complex a, complex b)
   { return new complex(a.re-b.re, a.im-b.im); }

public static complex operator*(complex a, double b)
   { return new complex(a.re*b, a.im*b); }
public static complex operator*(double a, complex b)
   { return new complex(a*b.re, a*b.im); }
public static complex operator*(complex a, complex b)
   { return new complex(a.re*b.re-a.im*b.im, a.re*b.im+a.im*b.re); }

public static complex operator/(complex a, double b){
   return new complex (a.re/b, a.im/b); }
public static complex operator/(complex a, complex b){
   if( SM.Abs(b.im)<SM.Abs(b.re) )
      {
         double e = b.im/b.re;
         double f = b.re+b.im*e;
         return new complex( (a.re+a.im*e)/f, (a.im-a.re*e)/f);
      }
   else
      {
         double e = b.re/b.im;
         double f = b.im+b.re*e;
         return new complex( (a.im+a.re*e)/f, (-a.re+a.im*e)/f);
      }
   }

public static bool operator==(complex a, complex b)
   { return (a.re==b.re) && (a.im==b.im); }
public static bool operator!=(complex a, complex b)
   { return (a.re!=b.re) || (a.im!=b.im); }

// methods

public void Print(string s){
   System.Console.WriteLine("{0} {1}",s,this);}

public override bool Equals(System.Object obj) {
      if (obj is complex)
      {
         complex b = (complex)obj;
         return this.re == b.re && this.im == b.im;
      }
      else { return false; }
   }

public override int GetHashCode(){
   throw new System.NotImplementedException(
         "complex.GetHashCode() is not implemented." );}

public override string ToString(){
   return System.String.Format("{0} {1}",re,im);}

public static complex Parse(string s) {
   string[] ss=s.Split(' ');
   return new complex(double.Parse(ss[0]),double.Parse(ss[1]));
   }

public double Abs(){ return Abs(this); }
public static double Abs(double x){ return SM.Abs(x); }
public static double Abs(complex z){
   double x=SM.Abs(z.re); double y=SM.Abs(z.im);
   if(x==0 && y==0) return 0;
   if(x>y) {double t=y/x; return x*SM.Sqrt(1.0+t*t);}
   else    {double t=x/y; return y*SM.Sqrt(1.0+t*t);} }

public complex Exp(){return Exp(this);}
public static double Exp(double x){ return SM.Exp(x); }
public static complex Exp(complex z){
   return new complex(SM.Cos(z.im),SM.Sin(z.im))*SM.Exp(z.re);}

public complex Pow(double x){return Exp(x*Log(this));}
public complex Conjugate(){return new complex(this.re,-this.im);}

public complex Sin(){ return Sin(this);}
public static double Sin(double x){ return SM.Sin(x); }
public static complex Sin(complex z){ return (Exp(I*z)-Exp(-I*z))/2/I; }

public complex Cos(){ return Cos(this);}
public static double Cos(double x){ return SM.Cos(x); }
public static complex Cos(complex z){ return (Exp(I*z)+Exp(-I*z))/2; }

public complex Log(){ return Log(this);}
public static double Log(double x){ return SM.Log(x); }
public static complex Log(complex z){
   return new complex( SM.Log(Abs(z)), SM.Atan2(z.im,z.re));}

public complex Sqrt(){ return Sqrt(this);}
public static complex Sqrt(complex z){ return Exp(Log(z)/2.0);}
public static complex Sqrt(double x){
   if(x>0) return SM.Sqrt(x);
   else return I*SM.Sqrt(-x);
   }

}

/*
public class Complex
    {
        private static System.Random RndObject = new System.Random();

        public const double MachineEpsilon = 5E-16;
        public const double MaxRealNumber = 1E300;
        public const double MinRealNumber = 1E-300;
        
        public static double RandomReal()
        {
            return RndObject.NextDouble();
        }
        public static int RandomInteger(int N)
        {
            return RndObject.Next(N);
        }
        public static double Sqr(double X)
        {
            return X*X;
        }        
        public static double Abscomplex(complex z)
        {
            double w;
            double xabs;
            double yabs;
            double v;
    
            xabs = System.Math.Abs(z.re);
            yabs = System.Math.Abs(z.im);
            w = xabs>yabs ? xabs : yabs;
            v = xabs<yabs ? xabs : yabs; 
            if( v==0 )
                return w;
            else
            {
                double t = v/w;
                return w*System.Math.Sqrt(1+t*t);
            }
        }
        public static complex Conj(complex z)
        {
            return new complex(z.re, -z.im); 
        }    
        public static complex CSqr(complex z)
        {
            return new complex(z.re*z.re-z.im*z.im, 2*z.re*z.im); 
        }

   public static complex Exp(complex z)
      { return new complex
      (System.Math.Cos(z.im),System.Math.Sin(z.im))*System.Math.Exp(z.re);}

}
*/
