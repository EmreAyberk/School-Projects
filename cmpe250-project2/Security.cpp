//
// Created by Emre_Ayberk on 06-Nov-18.
//

#include "Security.h"


Security::Security() {
    this->pastTime=0;
    this->isEmpty=false;
}

Security::Security(double pastTime, Passanger *x) {
    this->pastTime=pastTime;
    this->isEmpty=isEmpty;
    this->x= *x;
}

Security::~Security() {

}