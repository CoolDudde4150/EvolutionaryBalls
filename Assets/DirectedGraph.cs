using System.Collections.Generic;
using System;
using UnityEngine;

class Node<T> {

    public T value;
    public int ID;

    public Node(T value, int ID) {
        this.value = value;
        this.ID = ID;
    }

    public Node() {
    }
}

class DirectedGraph<T>
{
    List<Node<T>> vertices;
    List<List<Node<T>>> edges;

    public DirectedGraph(List<Node<T>> vertices, List<List<Node<T>>> edges) {
        this.vertices = vertices;
        this.edges = edges;
    }

    public DirectedGraph() {
        this.vertices = new List<Node<T>>();
        this.edges = new List<List<Node<T>>>();
    }

    public Node<T> addVertex(T value) {
        /* Adds a vertex to the end of the vertices list with the input value.
        */

        Node<T> node = new Node<T>(value, vertices.Count);
        vertices.Add(node);
        edges.Add(new List<Node<T>>());
        return node;
    }

    public void removeVertex(int index) {
        /* Removes the vertex at the index input into the function

        Also removes the edges list at the same index.
        */

        // The ID is intended to be a reverse search for where in the vertices list a Node is. If we delete a Node, we need to
        // adjust all the nodes after it to correctly align.
        for(int i = index; i < vertices.Count; i++) {
            vertices[i].ID--;
        }   

        vertices.RemoveAt(index);
        edges.RemoveAt(index);
    }

    public void removeVertex(Node<T> node) {
        /* Removes the vertex input into the function
        */

        int index = node.ID;

        // The ID is intended to be a reverse search for where in the vertices list a Node is. If we delete a Node, we need to
        // adjust all the nodes after it to correctly align.
        for(int i = index; i < vertices.Count; i++) {
            vertices[i].ID--;
        }   

        vertices.RemoveAt(index);
    }


    public void addEdge(int source, int destination) {

        // Ensures that the indexes exist
        if(source >= vertices.Count || destination >= vertices.Count || source < 0 || destination < 0) {
            return;
        }

        Node<T> destinationNode = vertices[destination];

        edges[source].Add(destinationNode);
    }

    public void addEdge(Node<T> source, Node<T> destination) {
        
        // Perform a simple check to ensure that at least the source is within indexing bounds.
        if(source.ID >= vertices.Count) {
            return;
        }

        edges[source.ID].Add(destination);
    }

    public void removeEdge(int source, int destination) {
        if(source >= vertices.Count || destination >= vertices.Count || source < 0 || destination < 0) {
            return;
        }

        edges[source].Remove(vertices[destination]);
    }

    public void removeEdge(Node<T> source, Node<T> destination) {
        if(source.ID >= vertices.Count) {
            return;
        }

        edges[source.ID].Remove(destination);
    }

    public void printConnections() {
        for(int i = 0; i < vertices.Count; i++) {
            Debug.Log($"Vertex {vertices[i].ID} is connected to:");
            for(int j = 0; j < edges[i].Count; j++) {
                Debug.Log(edges[i][j].ID);
            }
        }
    }
}
