//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_PASSANGER_H
#define UNTITLED_PASSANGER_H


class Passanger {
public:

    double arrive_time;

    double flight_time;

    double luggage_time;

    double security_time;

    double total_waiting_time;

    bool vip;

    bool online_ticket;

    Passanger();

    Passanger(double arrive_time, double flight_time, double luggage_time, double security_time, bool vip, bool online_ticket);

    void showInfo();

    ~Passanger();
};


#endif //UNTITLED_PASSANGER_H
