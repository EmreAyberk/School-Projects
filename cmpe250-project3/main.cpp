#include <iostream>
#include <list>
#include <stack>
#include <fstream>
#include <iterator>

#include "Graph.h"


using namespace std;


int main(int argc, char *argv[]) {


    ifstream input(argv[1]);

    int NumofPig;

    input >> NumofPig;

    Graph g1(NumofPig);

    int keycount;

    vector<vector<int>> keys;

    for (int i = 0; i < NumofPig; i++) {
        vector<int> pigkeys;
        input >> keycount;
        for (int j = 0; j < keycount; j++) {
            int id;
            input >> id;
            pigkeys.push_back(id);
        }
        keys.push_back(pigkeys);
    }

    g1.addEdge(keys);

    ofstream outputStream(argv[2]);
    outputStream << g1.broken.size() << " ";

    for (int k = 0; k < g1.broken.size(); k++) {
        outputStream << g1.broken[k] << " ";
    }


    return 0;
}