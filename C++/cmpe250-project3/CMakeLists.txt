cmake_minimum_required(VERSION 3.12)
project(project3)

set(CMAKE_CXX_STANDARD 14)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++14 -O2")

add_executable(project3 main.cpp Graph.cpp Graph.h)