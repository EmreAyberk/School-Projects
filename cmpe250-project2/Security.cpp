//
// Created by Emre_Ayberk on 06-Nov-18.
//

#include "Security.h"


Security::Security() {
    this->pastTime=0;

}

Security::Security(double pastTime, Passanger *x) {
    this->pastTime=pastTime;
    this->passanger = passanger;
}


bool Security::isEmpty(){
    return this->passanger = nullptr;
}

Security::~Security() {

}