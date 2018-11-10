//
// Created by Emre_Ayberk on 06-Nov-18.
//

#include "Luggage.h"


Luggage::Luggage() {
    this->pastTime=0;

}

Luggage::Luggage(double pastTime, Passanger *passanger) {
    this->pastTime=pastTime;
    this->passanger = passanger;

}

bool Luggage::isEmpty() {
return this->passanger = nullptr;
}

Luggage::~Luggage() {

}