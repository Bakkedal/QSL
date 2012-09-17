using sys=System;

public class vector{

//public static void Main(string[] args){ }

public int size, first;
public double[] data;

public vector(){
	size=1; first=0;
	data=new double[1];
	}

public vector(int size){
	this.size=size; first=0;
	data = new double[size];
	}

public vector(double[] v){
	size = v.Length; first=0;
	sys.Array.Copy(v,data,size);
	}

/*
public vector(vector b){
	size=b.size;
	stride=b.stride;
	data=new double[size];
	for(int i=0;i<size;i++)this[i]=b[i];
	}
*/

public double this[int i]{
	get{return data[first+i];}
	set{data[first+i]=value;}
	}

public vector scale(double z){
	for(int i=0;i<size;i++) this[i]*=z;
	return this;
	}

public double dot(vector b){
	double s=0; for(int i=0;i<size;i++)
		s+=this.data[first+i]*b.data[b.first+i];
	return s;
	}

public static double operator ^ (vector a, vector b){return a.dot(b);}

public double norm(){ return System.Math.Sqrt(this^this); }

public static vector operator * (double z, vector a){return a*z;}
public static vector operator * (vector a, double z){
	vector c = new vector(a.size);
	for(int i=0;i<a.size;i++) c[i]=a[i]*z;
	return c;
	}

public static vector operator / (vector a, double z){
	vector c = new vector(a.size);
	for(int i=0;i<a.size;i++) c[i]=a[i]/z;
	return c;
	}

public vector add(vector b){
	for(int i=0;i<size;i++) this[i]+=b[i];
	return this;
	}

public static vector operator + (vector a, vector b){
	vector c = new vector(a.size);
	for(int i=0;i<a.size;i++) c[i]=a[i]+b[i];
	return c;
	}

public static vector operator - (vector a, vector b){
	vector c = new vector(a.size);
	for(int i=0;i<a.size;i++) c[i]=a[i]-b[i];
	return c;
	}

public void print(){print("");}
public void print(string s){
	System.Console.WriteLine(s);
	for(int i=0;i<size;i++)System.Console.Write("{0:G5} ",this[i]);
	System.Console.WriteLine();
	}
public vector copy(){
	vector y=new vector(this.size);
	for(int i=0;i<this.size;i++)y[i]=this[i];
	return y;
	}

}
