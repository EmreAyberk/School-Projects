//
// Created by merve saglanmak on 14-Dec-18.
//

#ifndef PROJECT_4_TRAVERSAL_H
#define PROJECT_4_TRAVERSAL_H


class Traversal {
public:
    long cost;
    long endPoint;

    friend bool operator<(const Traversal &lhs, const Traversal &rhs) {
        return lhs.cost > rhs.cost;
    }
};


#endif //PROJECT_4_TRAVERSAL_H
