#include "LinkedList.h"

//Const
LinkedList::LinkedList() {
    length=0;
    head= nullptr;
    tail= nullptr;
}

//Copy
LinkedList::LinkedList(const LinkedList& list) {
    this->length = list.length;
    this->head = new Node(*list.head);
    this->tail = new Node(*list.tail);
}

//Copy Assignment
LinkedList& LinkedList::operator=(const LinkedList &list) {

    this->length=list.length;
    this->head=list.head;
    this->tail=list.tail;

    return *this;
}

//Move
LinkedList::LinkedList(LinkedList &&list) {

    this->length = move(list.length);
    this->head = move(list.head);
    this->tail = move(list.tail);

    list.head = nullptr;
    list.tail = nullptr;
    list.length = 0;

    /*
     * for(i=0;i<length-1;i++)
     * {
     * Node* temp=list.head;
     * list.head= list.head->next;
     * delete temp;
     * }
     */

}

//Move Assignment
LinkedList& LinkedList::operator=(LinkedList &&list) {
    this->length = move(list.length);
    this->head = move(list.head);
    this->tail = move(list.tail);


    list.head = nullptr;
    list.tail = nullptr;
    list.length = 0;

    /*
     * for(i=0;i<length-1;i++)
     * {
     * Node* temp=list.head;
     * list.head= list.head->next;
     * delete temp;
     * }
     */


    return *this;
}

//Push
void LinkedList::pushTail(string _name, float _amount) {
    Node* current = new Node(_name,_amount);

    if(tail== nullptr)
    {
        current->next=tail;
        head=current;
        tail=current;
        length++;
    }
    else{
        length++;
        tail->next=current;
        tail=tail->next;
    }

}

//Update
void LinkedList::updateNode(string _name, float _amount) {

    Node* temp = this->head;

    bool x=true;
    while(temp){
        if(temp->name==_name)
        {
         temp->amount=_amount;
         x=false;
         break;
        }

        temp=temp->next;

    }
    if(x) {
        pushTail(_name, _amount);
    }
}


//Destruct
LinkedList::~LinkedList() {
    if (length)
    {
        length=0;
    }
}