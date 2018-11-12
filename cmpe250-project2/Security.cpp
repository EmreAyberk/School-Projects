//
// Created by Emre_Ayberk on 06-Nov-18.
//

#include "Security.h"


Security::Security() {
    this->pastTime=0;
    this->passanger= nullptr;

}

Security::Security(double pastTime, Passanger *passanger) {
    this->pastTime=pastTime;
    this->passanger = passanger;
}


bool Security::isEmpty(){
    return this->passanger == nullptr;
}

Security::~Security() {

}