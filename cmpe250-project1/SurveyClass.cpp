#include "SurveyClass.h"

//Const
SurveyClass::SurveyClass() {
    members = new LinkedList();
}

//Copy
SurveyClass::SurveyClass(const SurveyClass &other) {

    members = new LinkedList(*other.members);
}

//Copy Operator
SurveyClass& SurveyClass::operator=(const SurveyClass &list) {
    if(this->members){
        delete this->members;
        members = list.members;
    }
}

//Move
SurveyClass::SurveyClass(SurveyClass &&other) {

    members = new LinkedList(*other.members);
    delete this->members;

}

//Move Operator
SurveyClass& SurveyClass::operator=(SurveyClass &&list) {
    if(this->members){
        delete this->members;
        members = list.members;
    }
}

//Dest
SurveyClass::~SurveyClass() {

    if(members->length)
    {
         members->length=0;
    }

}

//New Record
void SurveyClass::handleNewRecord(string _name, float _amount) {

    members->updateNode(_name, _amount);

}


//Min
float SurveyClass::calculateMinimumExpense() {

    Node* temp=members->head;

    float min=temp->amount;


    while(temp->next)
    {
        temp=temp->next;
        if(temp->amount<min)
        {
            min=temp->amount;
        }

    }

min=min*100;
int x=(int) min;
min=(float)x;
min=min/100;
    return min;
}

//Max
float SurveyClass::calculateMaximumExpense() {

    Node* temp=members->head;

    float max=temp->amount;

    while(temp)
    {
        
        if(temp->amount>max)
        {
            max=temp->amount;
        }
        temp=temp->next;

    }
    max=max*100;
    int x= (int)max;
    max=(float)x;
    max=max/100;
    return max;
}

//Avg
float SurveyClass::calculateAverageExpense() {

    float sum=0;
    float count=0;
    float avg=0;

    Node* temp=members->head;

    while(temp)
    {
        sum+=temp->amount;
        count++;
        temp=temp->next;
    }
    avg=sum/count;
    
    avg=avg*100;
    int x=(int)avg;
    avg=(float)x;
    avg=avg/100;

    
    return avg;
}