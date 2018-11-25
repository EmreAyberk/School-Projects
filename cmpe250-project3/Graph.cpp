//
// Created by Emre_Ayberk on 25-Nov-18.
//

#include "Graph.h"


Graph::Graph(int V) {

    this->V = V;

    this->adj = new list<int>[V+1];

    visited[0] = false;
    for (int i = 1; i <= V; i++) {
        visited[i] = false;
    }

}

void Graph::addEdge(vector<vector<int>> &keynum) {

    for (int i = 0; i < V; i++) {
        for (int j = 0; j < keynum[i].size(); ++j) {
            this->adj[i + 1].push_back(keynum[i][j]);
        }
    }


    for (int k = 1; k <= V; k++) {
        if(visited[k]) continue;
        broken.push_back(k);
        DFS(k, broken);
    }
}


void Graph::DFS(int v, vector<int> &breakables) {

    visited[v] = true;

    for (auto pos = adj[v].begin(); pos != adj[v].end(); ++pos) {
        int edgeId = *pos;

        bool wasBroken = false;
        for (auto posB = breakables.begin(); posB != breakables.end(); ++posB) {
            int brokenId = *posB;
            if (edgeId == brokenId) {
                breakables.erase(posB);
                wasBroken = true;
                break;
            }
        }
        if (wasBroken) continue;

        if (!visited[edgeId]) {
            DFS(edgeId, breakables);
        }
    }
}

Graph::~Graph() {
}
