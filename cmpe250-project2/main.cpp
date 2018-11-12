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

    if(e1->time == e2->time) {
        if(e1->type==e2->type) {
            return e1->passanger->arrive_time > e2->passanger->arrive_time;
        }
        return e1->type < e2->type;
    }

    return e1->time > e2->time;
}


bool compareLuggages(const Passanger* p1, const Passanger* p2) {
    if (flightPriority) {
        if(p1->flight_time==p2->flight_time){
            return p1->arrive_time> p2->arrive_time;
        } else{
        return p1->flight_time> p2->flight_time;
        }
    } else {
        return p1->luggage_arrive > p2->luggage_arrive;
    }
}

bool compareSecurity(const Passanger* p1, const Passanger* p2) {
    if (flightPriority) {
        if(p1->flight_time==p2->flight_time){
            return p1->arrive_time> p2->arrive_time;
        } else{
        return p1->flight_time> p2->flight_time;
        }
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
    double avg[8];
    int missed[8];

    for (int x = 0; x <8 ; x++) {
        counter=0;
        avg[x]=0;
        missed[x]=0;

        for (int i = 0; i < numofpas; i++) {
           event_queue.push(new Event(passengers[i], 0, passengers[i]->arrive_time));
        }

        cout << x << ". CASE"<< endl <<endl;

        switch (x){
            case 0:{
                flightPriority = false;
                vipTicket = false;
                onlineTicket = false;
                break;
            }
            case 1:{
                flightPriority = true;
                vipTicket = false;
                onlineTicket = false;
                break;
            }
            case 2:{
                flightPriority = false;
                vipTicket = true;
                onlineTicket = false;
                break;
            }
            case 3:{
                flightPriority = true;
                vipTicket = true;
                onlineTicket = false;
                break;
            }
            case 4:{
                flightPriority = false;
                vipTicket = false;
                onlineTicket = true;
                break;
            }
            case 5:{
                flightPriority = true;
                vipTicket = false;
                onlineTicket = true;
                break;
            }
            case 6:{
                flightPriority = false;
                vipTicket = true;
                onlineTicket = true;
                break;
            }
            case 7:{
                flightPriority = true;
                vipTicket = true;
                onlineTicket = true;
                break;
            }
        }


    while (!event_queue.empty()) {
        Event* event = event_queue.top();

     //  cout << event->time<< ' ';
        event_queue.pop();


        if (event->type == 0) { // Arrival
            if (onlineTicket && !event->passanger->online_ticket) { // bypass luggage

                //cout<< event->passanger->arrive_time<< "'te gelen Luggage bypass" << endl;
                event_queue.push( new Event(event->passanger, 1, event->time) );
            } else {
                bool entered = false;
                for (int i = 0; i < luggages.size(); i++) {
                    if (luggages[i]->isEmpty()) {

                        luggages[i]->passanger = event->passanger; // set passenger
                        event_queue.push( new Event(event->passanger, 1, event->time + event->passanger->luggage_time) ); // Luggage exit event
                        entered = true; // Entered luggage

                       // cout << event->passanger->arrive_time <<"'da gelen yolcu "<< event->time<<"'da luggage a girdi" << endl;
                        break;
                    }
                }

                if (!entered) { // Luggage wait queue
                    event->passanger->luggage_arrive = event->time;
                    luggage_queue.push(event->passanger);
                 //   cout<< event->passanger->arrive_time<<"'da gelen yolcu luggage_q'ya "<< event->passanger->luggage_arrive<<" da girdi" << endl;
                }
            }
        } else if (event->type == 1) { // Luggage exit
            for (int i = 0; i < luggages.size(); i++) {
                if (event->passanger == luggages[i]->passanger) {
                   // cout<< event->passanger->arrive_time<<"'da gelen yolcu " <<event->time<< "'da luggage dan çıktı" << endl;
                    luggages[i]->passanger = nullptr;

                    if (!luggage_queue.empty()) {
                        Passanger* passanger = luggage_queue.top();
                      //  cout<< luggage_queue.top()->arrive_time << "'da gelen yolcu q dan çıktı."<< endl;
                        luggage_queue.pop();


                        luggages[i]->passanger = passanger; // assign new passenger
                        event_queue.push( new Event(passanger, 1, event->time + passanger->luggage_time) ); // Luggage exit event

                    }
                    break;
                }
            }

            if (vipTicket && event->passanger->vip) { // bypass security
                event->passanger->total_waiting_time = event->time-event->passanger->arrive_time;
               // cout << event->passanger->arrive_time<<" 'da gelen yolcu " << event->time<<"'da çıkış yapıyor." << endl;
                event_queue.push(  new Event(event->passanger, 2, event->time) );
            } else {
                bool entered = false;
                for (int i = 0; i < securities.size(); i++) {
                    if (securities[i]->isEmpty()) {
                        securities[i]->passanger = event->passanger;
                        event_queue.push( new Event(event->passanger, 2, event->time + event->passanger->security_time) );

                        //cout << event->passanger->arrive_time << " 'da gelen yolcu " << event->time << " 'da sec e girdi" << endl;
                        entered = true;
                        break;
                    }
                }

                if (!entered) {
                    event->passanger->security_arrive = event->time;
                    security_queue.push(event->passanger);
                   // cout << event->passanger->arrive_time << " 'da gelen yolcu " << event->passanger->security_arrive << " 'da sec_q ya girdi" << endl;

                }
            }

        } else if (event->type == 2) { // Security exit
            for(int i=0;i< securities.size();i++) {
                if(event->passanger == securities[i]->passanger)
                {
                    securities[i]->passanger= nullptr;

                   // cout << event->passanger->arrive_time << " 'da gelen yolcu " << event->time << " 'da sec ten çıkar" << endl;

                    if(!security_queue.empty())
                    {

                        Passanger* passanger = security_queue.top();
                        security_queue.pop();

                        securities[i]->passanger=passanger;//assign new passenger
                        event_queue.push( new Event(passanger, 2, event->time + passanger->security_time) );
                     //   cout << event->passanger->arrive_time << " 'da gelen yolcu " << event->time << " 'da sec_q dan çıkar" << endl;


                        // SECURITY EXIT EVENT
                    }
                    break;
                }

            }

            event->passanger->total_waiting_time = event->time - event->passanger->arrive_time;
            avg[x]+=event->passanger->total_waiting_time;

            if(event->time>event->passanger->flight_time){
                counter++;
               // cout << event->passanger->arrive_time << " 'DA GELEN YOLCU " << event->passanger->flight_time <<" 'DAKİ UCAĞINI KAÇIRDI"<< endl;
            }
        }
        // printf("%d\n", event->time);

    }
        missed[x]=counter;
    }


for(int i=0; i<8;i++)
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


