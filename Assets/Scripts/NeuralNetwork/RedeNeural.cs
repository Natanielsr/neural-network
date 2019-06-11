using System;
public class RedeNeural
{
    int Input_Nodes;
    int Hidden_Nodes;
    int Output_Nodes;

    Matrix weigth_input_hidden;
    Matrix bias_input_hidden;
    Matrix weigth_hidden_output;
    Matrix bias_hidden_output;

    

    
    public RedeNeural(int Input_Nodes, int Hidden_Nodes,int Output_Nodes){
        this.Input_Nodes = Input_Nodes;
        this.Hidden_Nodes = Hidden_Nodes;
        this.Output_Nodes = Output_Nodes;

        this.bias_input_hidden = new Matrix(Hidden_Nodes, 1); //recebe aleatorio Hidden_Nodesx1
        this.bias_hidden_output =  new Matrix(Output_Nodes, 1); //recebe aleatorio  Output_Nodesx1

        

        this.weigth_input_hidden = new Matrix(Hidden_Nodes, Input_Nodes); //recebe aleatorio

        this.weigth_hidden_output = new Matrix(Output_Nodes, Hidden_Nodes); //recebe aleatorio

        

    }

    public void feedFoward(double[] inputArray){

        if(inputArray.Length != Input_Nodes)
            throw new Exception("Numero de inputs incorreto");
        //INPUT
        var inputMatrix = Matrix.ArrayParaMatrix(inputArray); //TRANSFORMA ARRAY EM MATRIX 

        inputMatrix.printMatrix();
        //this.weigth_input_hidden.printMatrix();
       
       //HIDDEN
        var hidden = Matrix.MultiplicaMatrizes
            (this.weigth_input_hidden, inputMatrix);//multiplica e soma os valores do input pelos pesos

       // hidden.printMatrix();
       // bias_input_hidden.printMatrix();

        hidden = Matrix.SomaMatrizes(hidden, this.bias_input_hidden); //adiciona o bias

        //hidden.printMatrix();

        hidden.SigmoidMatrix(); //transforma o valor entre 0 - 1 com sigmoid

        //hidden.printMatrix();

        //OUTPUT
        
        //repete o processo
        var outputMatrix = Matrix.MultiplicaMatrizes(this.weigth_hidden_output, hidden);
        outputMatrix = Matrix.SomaMatrizes(outputMatrix, this.bias_hidden_output);
        outputMatrix.SigmoidMatrix();

        outputMatrix.printMatrix();

    }

    
}