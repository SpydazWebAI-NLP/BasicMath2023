# Cartesian Coordinate Functions in VB.NET

This VB.NET class provides functionality for working with Cartesian coordinates in a 3D space. Cartesian coordinates are represented as a vector of X, Y, and Z components. The class allows for performing various operations such as addition, subtraction, cross product, dot product, normalization, and more.

## Getting Started

To use the `Cartesian` class in your VB.NET project, follow these steps:

1. Copy the `Cartesian` class code into your VB.NET project.
2. Ensure that the `RandomFactory` class (if used) is also available in your project or replace it with a suitable random number generator.
3. Once the `Cartesian` class is available in your project, you can create instances and perform various operations with Cartesian coordinates.

## Class Members

### Properties

- `x`: The X component of the Cartesian coordinate.
- `y`: The Y component of the Cartesian coordinate.
- `z`: The Z component of the Cartesian coordinate.

### Constructors

- `New()`: Default constructor to create an empty Cartesian (x, y, and z initialized to 0).
- `New(x As Single, y As Single, z As Single)`: Constructor for a 3D Cartesian with provided x, y, and z coordinates.
- `New(x As Single, y As Single)`: Constructor for a 2D Cartesian with provided x and y coordinates.

### Static Methods

- `Sub(v1 As Cartesian, v2 As Cartesian) As Cartesian`: Subtract one Cartesian from another and return the result as a new Cartesian.
- `Add(v1 As Cartesian, v2 As Cartesian) As Cartesian`: Add two Cartesians together and return the result as a new Cartesian.
- `AngleBetween(v1 As Cartesian, v2 As Cartesian) As Single`: Calculate and return the angle (in radians) between two Cartesians.
- `Cross(v1 As Cartesian, v2 As Cartesian) As Cartesian`: Calculate the cross product of two Cartesians and return the result as a new Cartesian.
- `Distance(v1 As Cartesian, v2 As Cartesian) As Single`: Calculate and return the Euclidean distance between two Cartesians.
- `Div(v As Cartesian, n As Single) As Cartesian`: Divide a Cartesian by a scalar and return the result as a new Cartesian.
- `Dot(v1 As Cartesian, v2 As Cartesian) As Single`: Calculate and return the dot product of two Cartesians.
- `Lerp(v1 As Cartesian, v2 As Cartesian, Amount As Single) As Cartesian`: Linear interpolate between two Cartesians and return the result as a new Cartesian.
- `Mult(v As Cartesian, n As Single) As Cartesian`: Multiply a Cartesian by a scalar and return the result as a new Cartesian.

### Instance Methods

- `[Set](x As Single, y As Single, z As Single) As Cartesian`: Set the x, y, and z components of the Cartesian coordinate.
- `[Set](x As Single, y As Single) As Cartesian`: Set the x and y components of the Cartesian coordinate.
- `[Set](v As Cartesian) As Cartesian`: Set the x, y, and z components of the Cartesian from another Cartesian.
- `[Set](source() As Single) As Cartesian`: Set the x, y, and z components of the Cartesian from a float array.
- `[Sub](v As Cartesian) As Cartesian`: Subtract x, y, and z components from the Cartesian.
- `[Sub](x As Single, y As Single) As Cartesian`: Subtract x and y components from the Cartesian.
- `[Sub](x As Single, y As Single, z As Single) As Cartesian`: Subtract x, y, and z components from the Cartesian.
- `Add(v As Cartesian) As Cartesian`: Add x, y, and z components to the Cartesian.
- `Add(x As Single, y As Single) As Cartesian`: Add x and y components to the Cartesian.
- `Add(x As Single, y As Single, z As Single) As Cartesian`: Add x, y, and z components to the Cartesian.
- `Copy() As Cartesian`: Create a copy of the Cartesian and return it as a new Cartesian.
- `Cross(v As Cartesian) As Cartesian`: Calculate the cross product of the Cartesian with another Cartesian and return the result as a new Cartesian.
- `Distance(v As Cartesian) As Single`: Calculate and return the Euclidean distance between this Cartesian and another Cartesian.
- `Div(n As Single) As Cartesian`: Divide the Cartesian by a scalar.
- `Dot(v As Cartesian) As Single`: Calculate and return the dot product of this Cartesian with another Cartesian.
- `Normalize() As Cartesian`: Normalize the Cartesian to a unit Cartesian (magnitude 1).
- `Normalize(target As Cartesian) As Cartesian`: Normalize the Cartesian and store the result in a target Cartesian.
- `ToString() As String`: Return the Cartesian coordinates as a string.

## License

This Cartesian class is provided under the [MIT License](LICENSE.md).

## Contributions

Contributions to this project are welcome. If you find any issues or want to suggest improvements, feel free to create a pull request or open an issue.

## Acknowledgments

The Cartesian class is inspired by the need for performing various operations with Cartesian coordinates in 3D space. Special thanks to the contributors and developers who have made this class possible.

---

Feel free to include any additional details or context relevant to your project in the README.