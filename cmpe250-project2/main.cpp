#include <iostream>
#include <queue>
#include <iterator>
#include <fstream>
#include <algorithm>
#include <functional>

#include "Passanger.h"
#include "Luggage.h"
#include "Security.h"
#include "Event.h"

using namespace std;

/*

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

*/

bool flightPriority = false;
bool vipTicket = false;
bool onlineTicket = false;

bool compareEvents(const Event* e1, const Event* e2) {
    return e1->time > e2->time;
}

bool compareLuggages(const Passanger* p1, const Passanger* p2) {
    if (flightPriority) {
        return p1->flight_time> p2->flight_time;
    } else {
        return p1->luggage_arrive > p2->luggage_arrive;
    }
}

bool compareSecurity(const Passanger* p1, const Passanger* p2) {
    if (flightPriority) {
        return p1->flight_time> p2->flight_time;
    } else {
        return p1->security_arrive > p2->security_arrive;
    }
}

double global_time = 0;

priority_queue<Event *, vector<Event *>, function<bool(Event *, Event *)>> event_queue(compareEvents);

priority_queue<Passanger *, vector<Passanger *>, function<bool(Passanger *, Passanger *)>> luggage_queue(compareLuggages);

priority_queue<Passanger *, vector<Passanger *>, function<bool(Passanger *, Passanger *)>> security_queue(compareSecurity);


vector<Passanger*> passengers;
vector<Luggage*> luggages;
vector<Security*> securities;



int main()
{

    ifstream input("C:\\Users\\Emre_Ayberk\\CLionProjects\\untitled\\input1");

    int numofpas;

    int numoflug;

    int numofsec;

    int P_time=0;

    input >> numofpas;

    input >> numoflug;

    input >> numofsec;

    Passanger psg[numofpas];

    for(int i=0; i<numofpas;i++)
    {
        int a, b, c, d;
        char e, f;
        input >> a >> b >> c >> d >> e >> f;
        passengers.push_back(new Passanger(a, b, c, d, e=='V', f=='L'));

    }

    for(int i=0; i<numoflug;i++)
    {
        luggages.push_back(new Luggage);
    }

    for(int i=0; i<numoflug;i++)
    {
        securities.push_back(new Security);
    }

    for (int i = 0; i < numofpas; i++) {
        event_queue.push(new Event(passengers[i], 0, passengers[i]->arrive_time));
    }

    double total = 0;

    int counter;
    double avg[8];
    int missed[8];

    for (int x = 1; x <9 ; x++) {
        switch (x){
            case 1:{
                flightPriority = false;
                vipTicket = false;
                onlineTicket = false;
            }
            case 2:{
                flightPriority = true;
                vipTicket = false;
                onlineTicket = false;
            }
            case 3:{
                flightPriority = false;
                vipTicket = true;
                onlineTicket = false;
            }
            case 4:{
                flightPriority = true;
                vipTicket = true;
                onlineTicket = false;
            }
            case 5:{
                flightPriority = false;
                vipTicket = false;
                onlineTicket = true;
            }
            case 6:{
                flightPriority = true;
                vipTicket = false;
                onlineTicket = true;
            }
            case 7:{
                flightPriority = false;
                vipTicket = true;
                onlineTicket = true;
            }
            case 8:{
                flightPriority = true;
                vipTicket = true;
                onlineTicket = true;
            }
        }


    while (!event_queue.empty()) {
        counter=0;
        Event* event = event_queue.top();
        event_queue.pop();

        if (event->type == 0) { // Arrival
            if (onlineTicket && event->passanger->online_ticket) { // bypass luggage
                event_queue.push( new Event(event->passanger, 1, event->time) );
            } else {
                bool entered = false;
                for (int i = 0; i < luggages.size(); i++) {
                    if (luggages[i]->isEmpty()) {
                        luggages[i]->passanger = event->passanger; // set passenger
                        event_queue.push( new Event(event->passanger, 1, event->time + event->passanger->luggage_time) ); // Luggage exit event
                        entered = true; // Entered luggage
                        break;
                    }
                }

                if (!entered) { // Luggage wait queue
                    event->passanger->luggage_arrive = event->time;
                    luggage_queue.push(event->passanger);
                }
            }
        } else if (event->type == 1) { // Luggage exit
            for (int i = 0; i < luggages.size(); i++) {
                if (event->passanger == luggages[i]->passanger) {
                    luggages[i]->passanger = nullptr;

                    if (!luggage_queue.empty()) {
                        Passanger* passanger = luggage_queue.top();
                        luggage_queue.pop();

                        luggages[i]->passanger = passanger; // assign new passenger
                        event_queue.push( new Event(passanger, 1, event->time + passanger->luggage_time) ); // Luggage exit event
                    }
                    break;
                }
            }

            if (vipTicket && event->passanger->vip) { // bypass security
                event->passanger->total_waiting_time = event->time-event->passanger->arrive_time;
                avg[x]+=event->passanger->total_waiting_time;
                if(event->passanger->total_waiting_time-event->passanger->flight_time<0){
                    counter++;
                }

                event_queue.push(  new Event(event->passanger, 2, event->time) );
            } else {
                bool entered = false;
                for (int i = 0; i < securities.size(); i++) {
                    if (securities[i]->isEmpty()) {
                        securities[i]->passanger = event->passanger;
                        event_queue.push( new Event(event->passanger, 2, event->time + event->passanger->security_time) );
                        entered = true;
                        break;
                    }
                }

                if (!entered) {
                    event->passanger->security_arrive = event->time;
                    security_queue.push(event->passanger);
                }
            }

        } else if (event->type == 2) { // Security exit
            for(int i=0;i< securities.size();i++) {
                if(event->passanger == securities[i]->passanger)
                {
                    securities[i]->passanger= nullptr;
                    if(!security_queue.empty())
                    {

                        Passanger* passanger = security_queue.top();
                        security_queue.pop();

                        securities[i]->passanger=passanger;//assign new passenger
                        event_queue.push(new Event(passanger,0,event->time+passanger->security_time) ); // Security exit evet

                        total += event->time - event->passanger->arrive_time+ passanger->security_time;
                        avg[x]+=total;


                    }
                    break;
                }
            }




        }

        missed[x]=counter;
    }

    }


for(int i=1; i<9;i++)
{
    cout<<avg[i]<< ' ' << missed[i];
}

    return 0;
}

// YARIN:

// SECURITY QUEUEDA ELEMAN VARSA SECURITY SOK ~~done
// SECURITYDEN ÇIKAR ~~done
// İSTATİSTİK TOPLA
// AYRI CASELER İÇİN DENE ~~done


