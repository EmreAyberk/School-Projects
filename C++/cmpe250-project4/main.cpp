#include <iostream>
#include <fstream>
#include <vector>
#include <cmath>
#include <limits>
#include <queue>

#include "Edge.h"
#include "Traversal.h"

using namespace std;
const long INF = numeric_limits<long>::max();


long vertesLoc2ID(long y, long x, long N) {
    return y * N + x;
};

int main(int argc, char *argv[]) {

    fstream input(argv[1]);

    long Width, Height;
    input >> Width >> Height;
    long totalVertex = Width * Height;

    vector<vector<long>> givenArray;
    givenArray.resize(totalVertex);

    for (long y = 0; y < Width; y++) {
        givenArray[y].resize(Width);
        for (long x = 0; x < Height; x++) {
            input >> givenArray[y][x];
        }
    }

    vector<vector<Edge>> adj;
    adj.resize(totalVertex);

    for (long y = 0; y < Width; y++) {
        for (long x = 0; x < Height; x++) {
            long currentHeight = givenArray[y][x];

            if (x != 0) {
                long leftX = x - 1;
                long leftHeight = givenArray[y][leftX];
                adj[vertesLoc2ID(y, x, Width)].emplace_back(
                        vertesLoc2ID(y, leftX, Width),
                        labs(leftHeight - currentHeight)
                );
            }
            if (x < Height - 1) {
                long rightX = x + 1;
                long rightHeight = givenArray[y][rightX];
                adj[vertesLoc2ID(y, x, Width)].emplace_back(
                        vertesLoc2ID(y, rightX, Width),
                        labs(rightHeight - currentHeight)
                );
            }
            if (y != 0) {
                long topY = y - 1;
                long topHeight = givenArray[topY][x];
                adj[vertesLoc2ID(y, x, Width)].emplace_back(
                        vertesLoc2ID(topY, x, Width),
                        labs(topHeight - currentHeight)
                );
            }
            if (y < Width - 1) {
                long botY = y + 1;
                long botHeight = givenArray[botY][x];
                adj[vertesLoc2ID(y, x, Width)].emplace_back(
                        vertesLoc2ID(botY, x, Width),
                        labs(botHeight - currentHeight)
                );
            }


        }
    }

    long outputCount;
    input >> outputCount;

    vector<vector<long>> startEnd;
    startEnd.resize(outputCount, vector<long>(4, -1));

    for (long i = 0; i < outputCount; i++) {
        input >> startEnd[i][0] >> startEnd[i][1] >> startEnd[i][2] >> startEnd[i][3];
        startEnd[i][0] -= 1;
        startEnd[i][1] -= 1;
        startEnd[i][2] -= 1;
        startEnd[i][3] -= 1;

    }


ofstream output(argv[2]);

    vector<long> costs;
    costs.resize(totalVertex);
    for (long i = 0; i < startEnd.size(); i++) {
        for (long j = 0; j < totalVertex; j++) {
            costs[j] = INF;
        }
        priority_queue<Traversal> pq;

        long startID = vertesLoc2ID(startEnd[i][0], startEnd[i][1], Width);
        long endID = vertesLoc2ID(startEnd[i][2], startEnd[i][3], Width);


        costs[startID] = 0;

        Traversal tr{};
        tr.cost = 0;
        tr.endPoint = startID;

        pq.push(tr);

        while (!pq.empty()) {
            Traversal curr = pq.top();
            pq.pop();

            if (curr.endPoint == endID) {
                output << curr.cost << endl;
                break;
            }


            for (long e = 0; e < adj[curr.endPoint].size(); e++) {

                Edge edge = adj[curr.endPoint][e];
                long cost = max(curr.cost, edge.weight);

                if (cost < costs[edge.target]) {
                    costs[edge.target] = cost;

                    Traversal eTr{};
                    eTr.cost = cost;
                    eTr.endPoint = edge.target;

                    pq.push(eTr);
                }


            }

        }

    }


    return 0;
}