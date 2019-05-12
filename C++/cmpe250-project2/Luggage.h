//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_LUGGAGE_H
#define UNTITLED_LUGGAGE_H

#include "Passanger.h"


class Luggage{
public:


    double pastTime;

    Passanger *passanger;

    
    bool isEmpty();

    Luggage();

    Luggage(double pastTime, Passanger *passanger);

    ~Luggage();




};



#endif //UNTITLED_LUGGAGE_H
