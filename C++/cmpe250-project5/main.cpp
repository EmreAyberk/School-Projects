#include <vector>
#include <string>
#include <iostream>
#include <fstream>
#include <unordered_map>

#define LARGE_PRIME 1000000007
using namespace std;


class spacer {
public:
    vector<string>* keywords;
    unordered_map<string, long> cache;

public:
    spacer(vector<string>* keywords) {
        this->keywords = keywords;
    }

    long countPossibilities(string remaining) {
        // did we calculate count for this string earlier?
        if (cache.find(remaining) != cache.end()) {
            // we found the result
            return cache[remaining];
        }

        if (remaining.empty()) {
            return 0;
        }

        long count = 0;
        for (auto it = keywords->begin(); it < keywords->end(); it++) {
            string& word = *it;
            string leftPart = remaining.substr(0, word.size());

            if (word == leftPart) {
                // are we at the end?
                if (word.length() == remaining.length()) {
                    count++;
                    continue;
                } else {
                    // then work on the right part of the message
                    string rightPart = remaining.substr(word.size());
                    count += countPossibilities(rightPart);
                }
            }
        }
        // save the # of possibilities for memoization
        cache[remaining] = count;
        return count % LARGE_PRIME;
    }


};

int main(int argc, char* argv[]) {
    ifstream input(argv[1]);
    ofstream output(argv[2]);

    string message;
    input >> message;

    int keywordCount;
    input >> keywordCount;
    vector<string> dict;
    for (int i = 0; i < keywordCount; i++) {
        string kw;
        input >> kw;
        dict.push_back(kw);
    }
    spacer sp(&dict);
    long result = sp.countPossibilities(message);
    output << result << endl;
}