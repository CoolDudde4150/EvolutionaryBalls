using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NeuralNetwork : MonoBehaviour 
{
    DirectedGraph<float> network;
    public int inputSize, outputSize;
    private void Start() {
        network = new DirectedGraph<float>();

        for(int i = 0; i < inputSize + outputSize; i++) {
            network.addVertex(1f);
        }
        
        network.addEdge(0, 2);
        network.addEdge(0, 1);
        network.addEdge(0,0);

        network.printConnections();
    }
    // NeuralNetwork(int inputSize, int outputSize) {
    //     network = new DirectedGraph<float>();

    //     for(int i = 0; i < inputSize + outputSize; i++) {
    //         network.addVertex(1f);
    //     }

    //     network.printConnections();
    // }
}
