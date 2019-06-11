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

        this.bias_input_hidden = new Matrix(Hidden_Nodes, 1);
        this.bias_hidden_output =  new Matrix(Output_Nodes, 1);

        
        //this.bias_input_hidden.printMatrix();
        //this.bias_hidden_output.printMatrix();

        this.weigth_input_hidden = new Matrix(Hidden_Nodes, Input_Nodes);

        this.weigth_hidden_output = new Matrix(Output_Nodes, Hidden_Nodes);

        //this.weigth_hidden_output.printMatrix();
        //this.weigth_input_hidden.printMatrix();
        

    }

    public void feedFoward(double[] inputArray){
        var inputMatrix = Matrix.ArrayParaMatrix(inputArray);
        inputMatrix.printMatrix();
        this.weigth_input_hidden.printMatrix();
       
        var hidden = Matrix.MultiplicaMatrizes(this.weigth_input_hidden, inputMatrix);
        hidden.printMatrix();
        bias_input_hidden.printMatrix();
        hidden = Matrix.SomaMatrizes(hidden, this.bias_input_hidden);
        hidden.printMatrix();
        hidden.SigmoidMatrix();
        hidden.printMatrix();
    }

    
}