//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_EVENT_H
#define UNTITLED_EVENT_H

#include "Passanger.h"

class Event {
public:

    Passanger* passanger;
    int type; // 0 -> Arrival, 1 -> Luggage Exit, 2 -> Security Exit
    double time;

    Event();

    Event(Passanger* passanger, int type, double time);

    ~Event();
};


#endif //UNTITLED_LUGGAGE_H
