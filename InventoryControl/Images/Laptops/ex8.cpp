#include<iostream>
using namespace std;
int main()
{
	float a,b,c,d,e,f,g;
	cout<<"Enter your weight(lb) :";
	cin>>a;
	cout<<"Enter your height(ft) :";
	cin>>b;
	cout<<"Enter your height(inch) :";
	cin>>c;
	e=b*12+c;
	d=e*e;
	f=a/d;
	g=f*703;
	if(g<18.5)
	    cout<<"Underweight";
	else if(g>=18.5 && g<=24.9)
	    cout<<"Normal or Healthy Weight";
	else if(g>=25.0 && g<=29.9)
	    cout<<"Overweight";
	else if(g>30)
	    cout<<"Obese";
	
return 0;	
}
