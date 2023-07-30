**Project: Probability Functions Library**

This project is a VB.NET library that provides various probability functions for calculating basic probabilities, conditional probabilities, and Bayesian probabilities. The library is designed to facilitate probability calculations in different scenarios and can be used in various applications.

**Usage Examples:**

1. **Calculating Joint Probability (ProbabilityOfAandB):**
   - Calculate the probability of events A and B both occurring.
   ```vb.net
   Dim probA As Integer = 0.6
   Dim probB As Integer = 0.4
   Dim jointProbability As Integer = Probability.ProbabilityOfAandB(probA, probB)
   Console.WriteLine("Joint Probability of A and B: " & jointProbability)
   ```

2. **Calculating Conditional Probability (ProbabilityOfAGivenB):**
   - Calculate the probability of event A given event B.
   ```vb.net
   Dim probA As Integer = 0.7
   Dim probB As Integer = 0.3
   Dim conditionalProbability As Integer = Probability.ProbabilityOfAGivenB(probA, probB)
   Console.WriteLine("Conditional Probability of A given B: " & conditionalProbability)
   ```

3. **Calculating Probability of an Event (FindProbabilityA):**
   - Calculate the probability of an event A given the number of favorable cases and the total number of cases.
   ```vb.net
   Dim favorableCases As Integer = 35
   Dim totalCases As Integer = 100
   Dim probabilityA As Integer = Probability.FindProbabilityA(favorableCases, totalCases)
   Console.WriteLine("Probability of Event A: " & probabilityA)
   ```

4. **Bayesian Probability Calculation (BayesProbabilityOfAGivenB):**
   - Calculate the probability of event A given event B using Bayes' theorem.
   ```vb.net
   Dim probA As Integer = 0.6
   Dim probB As Integer = 0.2
   Dim bayesProbability As Integer = Probability.BayesProbabilityOfAGivenB(probA, probB)
   Console.WriteLine("Bayesian Probability of A given B: " & bayesProbability)
   ```

5. **Calculating Odds Against and Odds Of (OddsAgainst, OddsOf):**
   - Calculate the odds against and odds of an event A given the number of unfavorable and favorable cases.
   ```vb.net
   Dim favorableCases As Integer = 40
   Dim unfavorableCases As Integer = 60
   Dim oddsAgainstA As Integer = Probability.OddsAgainst(favorableCases, unfavorableCases)
   Dim oddsOfA As Integer = Probability.OddsOf(favorableCases, unfavorableCases)
   Console.WriteLine("Odds Against A: " & oddsAgainstA)
   Console.WriteLine("Odds Of A: " & oddsOfA)
   ```

6. **Probability of Not an Event (ProbabilityOfNot):**
   - Calculate the probability of not event A given the probability of event A.
   ```vb.net
   Dim probA As Integer = 0.8
   Dim probabilityOfNotA As Integer = Probability.ProbabilityOfNot(probA)
   Console.WriteLine("Probability of Not A: " & probabilityOfNotA)
   ```

**Note:** Make sure to validate input values and handle any potential division by zero cases in the real-world application of these functions.

**Author: Leroy S Dyer**
**Year: 2016**

Feel free to use and extend this probability functions library in your projects. If you encounter any issues or have suggestions for improvements, please don't hesitate to provide feedback or contribute to the project. Happy probability calculations!