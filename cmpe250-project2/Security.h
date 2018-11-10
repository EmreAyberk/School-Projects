//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_SECURITY_H
#define UNTITLED_SECURITY_H

#include "Passanger.h"

class Security {
public:

    bool isEmpty;

    double pastTime;

    Passanger x;

    Security();

    Security(double pastTime, Passanger x);

    ~Security();

};


#endif //UNTITLED_SECURITY_H
