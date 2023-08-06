# Tensor.vb - A Flexible Tensor Library For .NET

![MIT License](https://img.shields.io/badge/license-MIT-green)

Tensor.vb Is an open-source .NET library that provides a flexible And generic implementation Of tensors, vectors, And matrices.This library allows users To perform a wide range Of tensor operations, including element-wise math operations, transfer functions, masking, transposing, And more.The library Is written In Visual Basic And targets .NET Framework, .NET Core, And .NET Standard, making it compatible with various .NET applications.

## Authors

- Leroy "Spydaz" Dyer
- ChatGPT 3.5 Davinci

## Key Features

1. Generic Tensor Implementation: The `Tensor(Of T)` Class Is a generic implementation Of a tensor, allowing users To work With tensors Of different data types (e.g., Double, Integer, Boolean, etc.).

2. Element-wise Math Operations: The `Tensor(Of T)` Class provides element-wise addition, subtraction, multiplication, And division Of tensors. Users can perform mathematical operations On tensors With ease.

3. Transfer Functions: The `Tensor(Of T)` Class includes common transfer functions Like the Sigmoid And ReLU functions. Users can easily apply these transfer functions To tensors.

4. Masking And Zero Masking: The library supports masking operations On tensors. Users can apply masks To tensors And selectively replace Or zero out elements based On the provided mask.

5. Transpose And Rotation: Users can transpose And rotate tensors, making it convenient For various matrix operations.

6. Dot Product And Matrix Multiplication: The library offers dot product computation For vectors And matrix multiplication For matrices.

7. Statistics And Normalization: Users can calculate statistics Like sum, mean, And standard deviation Of tensors. Additionally, vectors' L2 norm can be computed.

## Example Usages

### Element-wise Math Operations

```vb
' Create two tensors
Dim tensor1 As New Tensor(Of Integer)(2, 2)
tensor1.SetItem(0, 0, 1)
tensor1.SetItem(0, 1, 2)
tensor1.SetItem(1, 0, 3)
tensor1.SetItem(1, 1, 4)

Dim tensor2 As New Tensor(Of Integer)(2, 2)
tensor2.SetItem(0, 0, 5)
tensor2.SetItem(0, 1, 6)
tensor2.SetItem(1, 0, 7)
tensor2.SetItem(1, 1, 8)

' Element-wise addition
Dim resultAddition = tensor1 + tensor2

' Element-wise subtraction
Dim resultSubtraction = tensor1 - tensor2

' Element-wise multiplication
Dim resultMultiplication = tensor1 * tensor2

' Element-wise division
Dim resultDivision = tensor1 / tensor2
```

### Transfer Functions

```vb
' Create a tensor
Dim tensor As New Tensor(Of Double)(2, 2)
tensor.SetItem(0, 0, 1.0)
tensor.SetItem(0, 1, 2.0)
tensor.SetItem(1, 0, -3.0)
tensor.SetItem(1, 1, 4.0)

' Apply the sigmoid function
Dim resultSigmoid = tensor.Sigmoid()

' Apply the ReLU function
Dim resultReLU = tensor.ReLU()
```

### Masking And Zero Masking

```vb
' Create a tensor and mask
Dim tensor As New Tensor(Of Integer)(2, 2)
tensor.SetItem(0, 0, 1)
tensor.SetItem(0, 1, 2)
tensor.SetItem(1, 0, 3)
tensor.SetItem(1, 1, 4)

Dim mask As New Tensor(Of Boolean)(2, 2)
mask.SetItem(0, 0, True)
mask.SetItem(0, 1, False)
mask.SetItem(1, 0, False)
mask.SetItem(1, 1, True)

' Apply mask with replacement
Dim replacementValue As Integer = 99
Dim resultMaskWithReplacement = tensor.ApplyMaskWithReplacement(mask, replacementValue)

' Apply mask with zeroing
Dim resultMaskWithZero = tensor.ApplyMaskWithZero(mask)
```

### Transpose And Rotation

```vb
' Create a matrix
Dim matrix As New Matrix(Of Double)(2, 3)
matrix.SetItem(0, 0, 1.0)
matrix.SetItem(0, 1, 2.0)
matrix.SetItem(0, 2, 3.0)
matrix.SetItem(1, 0, 4.0)
matrix.SetItem(1, 1, 5.0)
matrix.SetItem(1, 2, 6.0)

' Transpose the matrix
Dim transposedMatrix = matrix.Transpose()

' Rotate the matrix 90 degrees
Dim rotatedMatrix = matrix.Rotate90Degrees()
```

### Dot Product And Matrix Multiplication

```vb
' Create two vectors
Dim vector1 As New Vector(Of Double)(3)
vector1.SetItem(0, 1.0)
vector1.SetItem(1, 2.0)
vector1.SetItem(2, 3.0)

Dim vector2 As New Vector(Of Double)(3)
vector2.SetItem(0, 4.0)
vector2.SetItem(1, 5.0)
vector2.SetItem(2, 6.0)

' Calculate dot product of vectors
Dim dotProductResult = vector1.DotProduct(vector2)

' Create two matrices
Dim matrix1 As New Matrix(Of Double)(2, 3)
matrix1.SetItem(0, 0, 1.0)
matrix1.SetItem(0, 1, 2.0)
matrix1.SetItem(0, 2, 3.0)
matrix1.SetItem(1, 0, 4.0)
matrix1.SetItem(1, 1, 5.0)
matrix1.SetItem(1, 2, 6.0)

Dim matrix2 As New Matrix(Of Double)(3, 2)
matrix2.SetItem(0, 0, 7.0)
matrix2.SetItem(0, 1, 8.0)
matrix2.SetItem(1, 0, 9.0)
matrix2.SetItem(1, 1, 10.0)
matrix

2.SetItem(2, 0, 11.0)
matrix2.SetItem(2, 1, 12.0)

' Perform matrix multiplication
Dim matrixMultiplicationResult = matrix1.Multiply(matrix2)
```

### Statistics And Normalization

```vb
' Create a vector
Dim vector As New Vector(Of Double)(3)
vector.SetItem(0, 1.0)
vector.SetItem(1, 2.0)
vector.SetItem(2, 3.0)

' Calculate vector statistics
Dim (sum, mean, stdDev) = vector.Statistics()

' Calculate vector L2 norm
Dim norm = vector.Norm()
```

## Unfinished Components

1. **Determinant Calculation**: The library provides a simple method For calculating the determinant Of a 2x2 matrix. However, the implementation For larger matrices Is Not yet complete. Users are encouraged To contribute by implementing determinant calculation Using LU decomposition Or other methods.

## Contribution And License

We welcome contributions To Tensor.vb! If you find any bugs, have feature suggestions, Or would Like To contribute New functionalities, feel free To open an issue Or submit a pull request.

Tensor.vb Is licensed under the MIT License, granting users the freedom To use, modify, And distribute the library for both personal And commercial purposes.

We hope you find Tensor.vb useful For your .NET projects! Happy coding!

_Leroy "Spydaz" Dyer & ChatGPT 3.5 Davinci_