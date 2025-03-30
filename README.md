# Graph Traversal

A c# / .net implementation for graph simple calculations 

## Description

1. Create a randomly generated a simple directed graph
2. Calculate the shortest path between 2 randomly selected vertices with Dijkstra's algorithm
3. Calculate distance properties of the graph (radius and diameter)
4. Calculate the eccentricity of a randomly selected vertex

## Getting Started

### Dependencies

.net 8.0

### Executing program

* How to run the program

There are two options to generate a graph

Option 1 - pass in two values (N - size of generated graph) and (S - sparseness (number of directed edges actually; from N-1 (inclusive) to N(N-1) (inclusive))) directly as arguments

  dotnet run -- \<N\> \<S\> (eg. dotnet run -- 6 10)

Option 2 - simply do "dotnet run" [if there are less than 2 arguments being put in, the terminal will ask for the user input]
  
  dotnet run

<img width="401" alt="image" src="https://github.com/user-attachments/assets/004304f9-bef7-4b8a-85c5-1711dff1e7ac" />

Once a graph is successfully created, all values will be calculated and displayed automatically 

<img width="523" alt="image" src="https://github.com/user-attachments/assets/0ebce4cb-7817-43ba-b0fd-a0f696c66ee5" />

## Remarks

A Clojure implementation can be found here: https://github.com/km-jonathan/GraphTraversalClojure

## Extra Info

- Initially, this project implemented straightforward model creation. It was later refactored to implement the Builder Design Pattern. 
As a result, some code may be outdated or no longer in use.

- A test project is also included for unit testing purposes. Additional unit testing could be created.

## Feedback

Looking forward to any feedback on how to optimise the code

## Authors

Jonathan Leung  

## Version History

1.0 - Initial Release
