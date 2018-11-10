//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_SECURITY_H
#define UNTITLED_SECURITY_H

#include "Passanger.h"

class Security {
public:

    double pastTime;

    Passanger *passanger;
    bool isEmpty();

    Security();

    Security(double pastTime, Passanger *passanger);

    ~Security();

};


#endif //UNTITLED_SECURITY_H
