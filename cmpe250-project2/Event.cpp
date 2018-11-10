//
// Created by Emre_Ayberk on 10-Nov-18.
//

#include "Event.h"

Event::Event() {
    this->passanger=0;
    this->type=0;
    this->time=0;
}

Event::Event(Passanger* passanger, int type, double time){
    this->passanger=passanger;
    this->type=type;
    this->time=time;
}

Event::~Event() {
}