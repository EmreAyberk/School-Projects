//
// Created by Emre_Ayberk on 06-Nov-18.
//
#include <iostream>
#include "Passanger.h"
using namespace std;

Passanger::Passanger() {
    this->arrive_time=0;
    this->flight_time=0;
    this->luggage_time=0;
    this->security_time=0;
    this->total_waiting_time=0;
    this->vip=false;
    this->online_ticket=false;

}


Passanger::Passanger(int arrive_time, int flight_time, int luggage_time, int security_time, bool vip, bool online_ticket) {
    this->arrive_time=arrive_time;
    this->flight_time=flight_time;
    this->luggage_time=luggage_time;
    this->security_time=security_time;
    this->vip=vip;
    this->online_ticket=online_ticket;




}

void Passanger::showInfo() {

        cout << arrive_time << ' ' << flight_time << ' ' << luggage_time << ' ' << security_time << ' ' << vip<< ' '
             << online_ticket << endl;

}
Passanger::~Passanger() {

}