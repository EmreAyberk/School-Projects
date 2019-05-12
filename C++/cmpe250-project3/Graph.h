//
// Created by Emre_Ayberk on 25-Nov-18.
//

#ifndef PROJECT3_SECOND_GRAPH_H
#define PROJECT3_SECOND_GRAPH_H

#include <vector>
#include <list>
#include <stack>
#include <set>
#include <algorithm>

using namespace std;

class Graph {

public:

    int V;

    vector<vector<int>> keynum;

    std::list<int> *adj;
    vector<int> broken;

    bool visited[1000000];

    void addEdge(vector<vector <int>>& keynum);

    void DFS(int v, vector<int> &breakables);

    Graph(int V);

    ~Graph();

};


#endif //PROJECT3_SECOND_GRAPH_H
