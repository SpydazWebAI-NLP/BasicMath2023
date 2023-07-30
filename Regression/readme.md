**Linear Regression Utility**

This is a simple VB.NET utility for performing linear regression analysis, including interpolation and extrapolation, based on X and Y data variables. The utility provides methods to predict Y for a given X value (interpolation) and to predict X for a given Y value (extrapolation). It also checks for the correlation of the data to determine the accuracy of the predictions.

### How to Use

1. **DataPair Structure**:
   - The `DataPair` structure represents a single data point consisting of two integer values: `Xvect` (the independent variable) and `Yvect` (the dependent variable).

2. **Creating a Regression Table**:
   - To perform linear regression analysis, you need to create a `RegressionTable` from a list of data pairs. Use the `CreateTable` function, passing the list of data pairs as an argument. This function calculates the necessary statistics required for regression analysis, such as sums, squared values, standard deviations, slope, and Y-intercept.

3. **Interpolation**:
   - To perform interpolation and predict Y for a given X value, use the `Interpolation` function. Pass the list of data pairs and the target X value as arguments. The function will return the corresponding predicted Y value.

4. **Extrapolation**:
   - To perform extrapolation and predict X for a given Y value, use the `Extrapolation` function. Pass the list of data pairs and the target Y value as arguments. The function will return the corresponding predicted X value.

5. **CoefficiantCorrelation**:
   - The `CoefficiantCorrelation` function is used internally to check if there is a positive or negative correlation between X and Y. It is based on the coefficient of correlation and determines the accuracy of the predictions.

### Example Usage

```vb.net
Dim dataPoints As New List(Of DataPair)()
' Add data points to the list (Xvect, Yvect)
dataPoints.Add(New DataPair(1, 2))
dataPoints.Add(New DataPair(2, 4))
dataPoints.Add(New DataPair(3, 6))
dataPoints.Add(New DataPair(4, 8))

Dim xValue As Double = 5
Dim yValue As Double = 10

' Perform Linear Regression and create the regression table
Dim regressionTable As RegressionTable = BasicRegression.CreateTable(dataPoints)

' Perform interpolation and predict Y for a given X value
Dim interpolatedY As Double = BasicRegression.Interpolation(dataPoints, xValue)

' Perform extrapolation and predict X for a given Y value
Dim extrapolatedX As Double = BasicRegression.Extrapolation(dataPoints, yValue)
```

### Note

- The utility assumes a linear relationship between X and Y.
- Additional error handling and validation may be required for real-world applications.
- Feel free to modify and extend the utility according to your specific needs.

*This utility was last updated on [DATE], and it's part of the [PROJECT NAME] project.*