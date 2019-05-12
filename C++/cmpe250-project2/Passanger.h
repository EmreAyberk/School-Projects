//
// Created by Emre_Ayberk on 06-Nov-18.
//

#ifndef UNTITLED_PASSANGER_H
#define UNTITLED_PASSANGER_H


class Passanger {
public:

    int arrive_time;

    int flight_time;

    int luggage_time;

    int luggage_arrive;

    int security_time;

    int security_arrive;

    int total_waiting_time;

    bool vip;

    bool online_ticket;

    Passanger();

    Passanger(int arrive_time, int flight_time, int luggage_time, int security_time, bool vip, bool online_ticket);

    void showInfo();

    ~Passanger();
};


#endif //UNTITLED_PASSANGER_H
