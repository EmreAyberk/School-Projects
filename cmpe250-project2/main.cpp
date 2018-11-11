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



    input >> numofpas;

    input >> numoflug;

    input >> numofsec;

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




    int counter;
    float avg[8];
    int missed[8];

    for (int x = 0; x <8 ; x++) {
        counter=0;

        for (int i = 0; i < numofpas; i++) {
           event_queue.push(new Event(passengers[i], 0, passengers[i]->arrive_time));
        }

        switch (x){
            case 0:{
                flightPriority = false;
                vipTicket = false;
                onlineTicket = false;
            }
            case 1:{
                flightPriority = true;
                vipTicket = false;
                onlineTicket = false;
            }
            case 2:{
                flightPriority = false;
                vipTicket = true;
                onlineTicket = false;
            }
            case 3:{
                flightPriority = true;
                vipTicket = true;
                onlineTicket = false;
            }
            case 4:{
                flightPriority = false;
                vipTicket = false;
                onlineTicket = true;
            }
            case 5:{
                flightPriority = true;
                vipTicket = false;
                onlineTicket = true;
            }
            case 6:{
                flightPriority = false;
                vipTicket = true;
                onlineTicket = true;
            }
            case 7:{
                flightPriority = true;
                vipTicket = true;
                onlineTicket = true;
            }
        }


    while (!event_queue.empty()) {
        Event* event = event_queue.top();

      //  cout << event_queue.top()->passanger->arrive_time << ' ';
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
                    luggages[i]->passanger = NULL;

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
                    securities[i]->passanger= NULL;
                    if(!security_queue.empty())
                    {

                        Passanger* passanger = security_queue.top();
                        security_queue.pop();

                        securities[i]->passanger=passanger;//assign new passenger
                        event_queue.push( new Event(passanger, 2, event->time + event->passanger->security_time) );
                        // SECURITY EXIT EVENT
                    }
                    break;
                }

            }

            event->passanger->total_waiting_time = event->time - event->passanger->arrive_time;
            avg[x]+=event->passanger->total_waiting_time;

            if(event->passanger->total_waiting_time-event->passanger->flight_time<0){
                counter++;
            }
        }
        // printf("%d\n", event->time);

    }
        missed[x]=counter;
    }


for(int i=1; i<9;i++)
{
    cout<<(avg[i]/numofpas) << ' ' << missed[i] << endl;
}

    return 0;
}

// YARIN:

// SECURITY QUEUEDA ELEMAN VARSA SECURITY SOK ~~done
// SECURITYDEN ÇIKAR ~~done
// İSTATİSTİK TOPLA
// AYRI CASELER İÇİN DENE ~~done


