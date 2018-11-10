#include <iostream>
#include <queue>
#include <iterator>
#include <fstream>
#include <algorithm>

#include "Passanger.h"
#include "Luggage.h"
#include "Security.h"

using namespace std;



// check queue funcs
int checklug(vector<Luggage*> x,int size)
{
    int counter=0;

    bool full=false;
    for(int i=0;i<size;i++)
    {
        if(!x[i]->isEmpty)
        {
            counter++;
        }
    }

    if(counter==size) {
        return full= true;
    } else return full;
}

int chechsec(vector <Security*> x, int size)
{
    int counter=0;

    bool full=false;
    for(int i=0;i<size;i++)
    {
        if(!x[i]->isEmpty)
        {
            counter++;
        }
    }

    if(counter==size) {
        return full= true;
    } else return full;

}
// end of check queue


//add que according to check result. LUGGAGE
void Lug_q(vector<Passanger*> Psg_lug ,Passanger *p, vector <Luggage*> lug, int l_size)
{
    if(checklug(lug,l_size)==1)
    {
        Psg_lug.push_back(p);
    } else{
        for(int i=0;i<l_size;i++)
        {
            if(lug[i]->isEmpty)
            {
                lug[i]->x=p;
            }
        }
    }
}

//add que according to check result. SECURITY
void Sec_q(vector <Passanger*> Psg_sec, Passanger *p, vector <Security*> sec, int s_size)
{
    if(chechsec(sec,s_size))
    {
        Psg_sec.push_back(p);
    } else{
        for(int i=0; i<s_size; i++)
        {
            if(sec[i]->isEmpty)
            {
                sec[i]->x=p;
            }
        }
    }
}


// SEND PASSANGER FROM luggage TO security

void Lugg2Sec(vector <Passanger*> Psg_sec, vector <Luggage*> lug, vector <Security*> sec, int l_size, int s_size)
{
    bool set=false;
    for (int i = 0; i < l_size; i++) {
        if(lug[i]->pastTime==lug[i]->x->luggage_time)
        {
            for(int j=0;j<s_size;j++)
            {
                if(sec[j]->isEmpty)
                {
                    sec[j]->x=lug[i]->x;
                    set= true;
                }
            }
            if(!set)
            {
                Psg_sec.push_back(lug[i]->x);
            }
            lug[i]->x= NULL;
        }
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
        psg[i] = Passanger(a, b, c, d, e=='V', f=='L');

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



