using System;
using System.Collections.Generic;
using UnityEngine;
public class Matrix
{
    public int rows { get; set; }
    public int cols { get; set; }
    public double[][] data { get; set; }


    public Matrix(int rows, int cols){
        this.rows = rows;
        this.cols = cols;
        this.data = new double[rows][];
        
        for (int i = 0; i < rows; i++)
        {
            double[] arr = new double[cols];
            for (int j = 0; j < cols; j++)
            {
                arr[j] = RandomNumber();
            }

            //UnityEngine.Debug.Log(arr);

            this.data[i] = arr;
            
        }

    }

    public static Matrix ArrayParaMatrix(double[] array){
        var matrix = new Matrix(array.Length, 1);

        for (int i = 0; i < matrix.data.Length; i++)
        {
            var arr = matrix.data[i];
            for(int j = 0; j < arr.Length; j++)
            {
                matrix.data[i][j] = array[i];
            }
        }

        return matrix;
    }


    public static Matrix SomaMatrizes(Matrix A,Matrix B){
        
        var novaMatrix = new Matrix(A.rows, A.cols);

        for (int i = 0; i < A.data.Length; i++)
        {
            var arr =  A.data[i];
            for (int j = 0; j < arr.Length; j++)
            {
                novaMatrix.data[i][j] = A.data[i][j] + B.data[i][j];
            }
        }

        return novaMatrix;

    }

    public static Matrix MultiplicaMatrizes(Matrix A,Matrix B){
        
        var novaMatrix = new Matrix(A.rows, B.cols);

        for (int i = 0; i < novaMatrix.data.Length; i++)
        {
            var arr =  novaMatrix.data[i];
            for (int j = 0; j < arr.Length; j++)
            {
                novaMatrix.data[i][j] = MultiplicaElementos(A, B, i, j);
            }
        }

        return novaMatrix;

    }

    static double MultiplicaElementos(Matrix A,Matrix B, int i, int j){
        var soma = 0.0;
        for (int k = 0; k < A.cols; k++)
        {
            var elm1 = A.data[i][k];
            var elm2 = B.data[k][j];

            soma += elm1 * elm2;
        }
        return soma;
    }



    public void printMatrix( ){
        var matrix = this;
        UnityEngine.Debug.Log("Matrix---------------------------------------");
        foreach(var arr in matrix.data){
            var line = "";
            foreach(var value in arr){
                line = line+ value.ToString()+", ";
            }
            UnityEngine.Debug.Log(line);
            
        }
        UnityEngine.Debug.Log("---------------------------------------");
    }

    public double RandomNumber()  
    {  
        int min = 0, max = 100;
        var rand = UnityEngine.Random.Range(min, max);
      //  var res = rand * 0.01; 
        return rand;  
    } 

    
}