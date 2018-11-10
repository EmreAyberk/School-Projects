#include <iostream>
#include <queue>
#include <iterator>
#include <fstream>
#include <algorithm>

#include "Passanger.h"
#include "Luggage.h"
#include "Security.h"

using namespace std;



// Add queue func
int checklug(Luggage x[],int size)
{
    int counter=0;

    bool full=false;
    for(int i=0;i<size;i++)
    {
        if(!x[i].isEmpty)
        {
            counter++;
        }
    }

    if(counter==size) {
        return full= true;
    } else return full;
}

int chechsec(Security x[], int size)
{
    int counter=0;

    bool full=false;
    for(int i=0;i<size;i++)
    {
        if(!x[i].isEmpty)
        {
            counter++;
        }
    }

    if(counter==size) {
        return full= true;
    } else return full;

}
// end of Add queue




void Lugg_q(vector<Passanger> lug ,Passanger p,Luggage l[], int p_size, int l_size)
{

    if(checklug(l,l_size)==1)
    {
        lug.push_back(p);
    } else{

    }


}





int main()
{

    ifstream input("C:\\Users\\Emre_Ayberk\\CLionProjects\\untitled\\input1");

    int numofpas;

    int numoflug;

    int numofsec;

    int time=0;

    input >> numofpas;

    input >> numoflug;

    input >> numofsec;

    Passanger psg[numofpas];

    for(int i=0; i<numofpas;i++)
    {
        int a, b, c, d;
        char e, f;
        input >> a >> b >> c >> d >> e >> f;
        psg[i] = *new Passanger(a, b, c, d, e=='V', f=='L');

    }


    Luggage lgg[numoflug];
    for(int i=0; i<numoflug;i++)
    {
        lgg[i]= *new Luggage;
    }


    Security scr[numofsec];
    for(int i=0; i<numoflug;i++)
    {
        scr[i]= *new Security;
    }






    for(int i=0;i<numofpas;i++)
    {
        psg[i].showInfo();
    }

    return 0;
}



