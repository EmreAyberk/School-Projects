//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_LUGGAGE_H
#define UNTITLED_LUGGAGE_H

#include "Passanger.h"


class Luggage{
public:

    bool isEmpty;

    double pastTime;

    Passanger x[20];

    Luggage();

    Luggage(double pastTime,Passanger x);

    ~Luggage();


};


#endif //UNTITLED_LUGGAGE_H
