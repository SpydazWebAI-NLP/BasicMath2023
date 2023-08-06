# Math Extensions Models

## Description
This repository contains three classes: `Vector`, `Matrix`, and `Tensor`, that are part of the Math Extensions library. These classes are designed to provide essential functionalities for mathematical operations involving vectors, matrices, and tensors.

## Class Descriptions

### Vector
The `Vector` class represents a one-dimensional array of numeric values. It provides various methods for performing operations on vectors, such as addition, subtraction, dot product, element-wise multiplication, and more.

### Matrix
The `Matrix` class represents a two-dimensional array of numeric values, where each row is represented as a `Vector`. It offers functionalities for matrix operations, including matrix addition, matrix multiplication, transposition, and more.

### Tensor
The `Tensor` class is a higher-level data structure representing a collection of `Matrix` objects. Each `Matrix` within the tensor represents a different dimension of data. The class provides functionalities for tensor operations, such as tensor addition and multiplication.

## How to Use

1. Import the Math Extensions namespace: 
   ```vb
   Imports MATH_EXTENSIONS
   Imports MATH_EXTENSIONS.MathsExt.LocationalSpace
   ```

2. Create a `Vector`, `Matrix`, or `Tensor` object:
   ```vb
   Dim myVector As New Vector()
   Dim myMatrix As New Matrix()
   Dim myTensor As New Tensor()
   ```

3. Perform operations on the objects:
   ```vb
   ' Vector operations
   Dim sumVector As Vector = Vector.AddVectors(vector1, vector2)
   Dim dotProduct As Double = Vector.CalculateDotProduct(vector1, vector2)

   ' Matrix operations
   Dim resultMatrix As Matrix = Matrix.ConcatenateMatricesVertically(matrix1, matrix2)
   Dim transposedMatrix As Matrix = matrix.Transpose()

   ' Tensor operations
   Dim resultTensor As Tensor = tensor1.Add(tensor2)
   Dim multipliedTensor As Tensor = tensor1.Multiply(tensor2)
   ```

4. Additional Functionalities:
   - Serializing/Deserializing:
     ```vb
     ' Vector to JSON
     Dim jsonString As String = myVector.ToJson()
     ' JSON to Vector
     Dim deserializedVector As Vector = Vector.FromJson(jsonString)

     ' Vector to XML
     myVector.ToXML("vector.xml")
     ' XML to Vector
     Dim deserializedVector As Vector = Vector.FromXML("vector.xml")
     ```

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributions
Contributions to this repository are welcome. Please feel free to open a pull request with any improvements or fixes.

## Authors
- [Your Name](https://github.com/yourusername)

## Acknowledgments
Special thanks to the Math Extensions library contributors for the foundation of these classes.

## Contact
For any questions or inquiries, please contact [your.email@example.com](mailto:your.email@example.com).