Namespace MATH_EXTENSIONS

    Namespace MathsExt

        Namespace AdvancedMath
            ''' <summary>
            ''' Important Probability functions
            ''' </summary>
            Public Class Probability

                Public Function ProbabilityOfAandB(ByRef ProbabilityOFA As Integer, ByRef ProbabilityOFB As Integer) As Integer
                    Return ProbabilityOfAnB(ProbabilityOFA, ProbabilityOFB)
                End Function

                Public Function ProbabilityOfAGivenB(ByRef ProbabilityOFA As Integer, ByRef ProbabilityOFB As Integer) As Integer
                    Return BasicProbability.ProbabilityOfAGivenB(ProbabilityOFA, ProbabilityOFB)
                End Function

                Public Function FindProbabilityA(ByRef NumberofACases As Integer, ByRef TotalNumberOfCases As Integer) As Integer
                    Return ProbablitiyOf(NumberofACases, TotalNumberOfCases)
                End Function

                Public Shared Function BayesProbabilityOfAGivenB(ByRef ProbA As Integer, ProbB As Integer) As Integer
                    BayesProbabilityOfAGivenB = (ProbabilityofBgivenA(ProbA, ProbB) * ProbA) / ProbabilityOfData(ProbA, ProbB)
                End Function

                Public Shared Function OddsAgainst(ByRef NumberOfFavCases As Integer, ByRef NumberOfUnfavCases As Integer) As Integer
                    OddsAgainst = NumberOfUnfavCases / NumberOfFavCases
                End Function

                Public Shared Function OddsOf(ByRef NumberOfFavCases As Integer, ByRef NumberOfUnfavCases As Integer) As Integer
                    OddsOf = NumberOfFavCases / NumberOfUnfavCases
                End Function

                Public Shared Function ProbabilityOfAnB(ByRef ProbA As Integer, ProbB As Integer) As Integer
                    ProbabilityOfAnB = ProbA * ProbB
                End Function

                Public Shared Function ProbabilityofBgivenA(ByRef ProbA As Integer, ProbB As Integer) As Integer
                    ProbabilityofBgivenA = ProbabilityOfAnB(ProbA, ProbB) / ProbA
                End Function

                Public Shared Function ProbabilityofBgivenNotA(ByRef ProbA As Integer, ProbB As Integer) As Integer
                    ProbabilityofBgivenNotA = 1 - ProbabilityOfAnB(ProbA, ProbB) / ProbA
                End Function

                Public Shared Function ProbabilityOfData(ByRef ProbA As Integer, ProbB As Integer) As Integer
                    'P(D)
                    ProbabilityOfData = (ProbabilityofBgivenA(ProbA, ProbB) * ProbA) + (ProbabilityofBgivenNotA(ProbA, ProbB) * ProbabilityOfNot(ProbA))

                End Function

                Public Shared Function ProbabilityOfNot(ByRef Probablity As Integer) As Integer
                    ProbabilityOfNot = 1 - Probablity
                End Function

                Public Shared Function ProbablitiyOf(ByRef NumberOfFavCases As Integer, ByRef TotalNumberOfCases As Integer) As Integer
                    'P(H)
                    ProbablitiyOf = NumberOfFavCases / TotalNumberOfCases
                End Function

                'Author : Leroy S Dyer
                'Year : 2016
                Public Class BasicProbability

                    ''' <summary>
                    ''' P(AnB) probability of both true
                    ''' </summary>
                    ''' <param name="ProbA"></param>
                    ''' <param name="ProbB"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbabilityOfAandB(ByRef ProbA As Integer, ProbB As Integer) As Integer
                        'P(A&B) probability of both true
                        ProbabilityOfAandB = ProbA * ProbB
                    End Function

                    'Basic
                    ''' <summary>
                    ''' P(A | B) = P(B | A) * P(A) / P(B) the posterior probability, is the probability for
                    ''' A after taking into account B for and against A. P(A | B), a conditional
                    ''' probability, is the probability of observing event A given that B is true.
                    ''' </summary>
                    ''' <param name="ProbA"></param>
                    ''' <param name="ProbB"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbabilityOfAGivenB(ByRef ProbA As Integer, ProbB As Integer) As Integer
                        'P(A | B) = P(B | A) * P(A) / P(B)
                        'the posterior probability, is the probability for A after taking into account B for and against A.
                        'P(A | B), a conditional probability, is the probability of observing event A given that B is true.
                        ProbabilityOfAGivenB = ProbabilityofBgivenA(ProbA, ProbB) * ProbA / ProbB
                    End Function

                    ''' <summary>
                    ''' p(B|A) probability of B given A the conditional probability or likelihood, is the
                    ''' degree of belief in B, given that the proposition A is true. P(B | A) is the
                    ''' probability of observing event B given that A is true.
                    ''' </summary>
                    ''' <param name="ProbA"></param>
                    ''' <param name="ProbB"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbabilityofBgivenA(ByRef ProbA As Integer, ProbB As Integer) As Integer
                        'p(B|A) probability of B given A
                        'the conditional probability or likelihood, is the degree of belief in B, given that the proposition A is true.
                        'P(B | A) is the probability of observing event B given that A is true.
                        ProbabilityofBgivenA = ProbabilityOfAandB(ProbA, ProbB) / ProbA
                    End Function

                    ''' <summary>
                    ''' P(B|'A) Probability of Not A Given B the conditional probability or likelihood, is
                    ''' the degree of belief in B, given that the proposition A is false.
                    ''' </summary>
                    ''' <param name="ProbA"></param>
                    ''' <param name="ProbB"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbabilityofBgivenNotA(ByRef ProbA As Integer, ProbB As Integer) As Integer
                        'P(B|'A) Probability of Not A Given B
                        'the conditional probability or likelihood, is the degree of belief in B, given that the proposition A is false.
                        ProbabilityofBgivenNotA = 1 - ProbabilityOfAandB(ProbA, ProbB) / ProbA
                    End Function

                    ''' <summary>
                    ''' P('H) Probability of Not the case is the corresponding probability of the initial
                    ''' degree of belief against A: 1 − P(A) = P(−A)
                    ''' </summary>
                    ''' <param name="Probablity"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbabilityOfNot(ByRef Probablity As Integer) As Integer
                        'P('H) Probability of Not the case
                        'is the corresponding probability of the initial degree of belief against A: 1 − P(A) = P(−A)
                        ProbabilityOfNot = 1 - Probablity
                    End Function

                    ''' <summary>
                    ''' P(H) Probability of case the prior probability, is the initial degree of belief in A.
                    ''' </summary>
                    ''' <param name="NumberOfFavCases"></param>
                    ''' <param name="TotalNumberOfCases"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbablitiyOf(ByRef NumberOfFavCases As Integer, ByRef TotalNumberOfCases As Integer) As Integer
                        'P(H) Probability of case
                        'the prior probability, is the initial degree of belief in A.
                        ProbablitiyOf = NumberOfFavCases / TotalNumberOfCases
                    End Function

                End Class

                ''' <summary>
                ''' Naive Bayes where A and B are events. P(A) and P(B) are the probabilities of A and B
                ''' without regard to each other. P(A | B), a conditional probability, is the probability of
                ''' observing event A given that B is true. P(B | A) is the probability of observing event B
                ''' given that A is true. P(A | B) = P(B | A) * P(A) / P(B)
                ''' </summary>
                ''' <remarks></remarks>
                Public Class Bayes
                    'where A and B are events.
                    'P(A) and P(B) are the probabilities of A and B without regard to each other.
                    'P(A | B), a conditional probability, is the probability of observing event A given that B is true.
                    'P(B | A) is the probability of observing event B given that A is true.
                    'P(A | B) = P(B | A) * P(A) / P(B)

                    ''' <summary>
                    ''' ProbA
                    ''' </summary>
                    ''' <param name="NumberOfFavCases"></param>
                    ''' <param name="TotalNumberOfCases"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function Likelihood(ByRef NumberOfFavCases As Integer, ByRef TotalNumberOfCases As Integer) As Integer
                        'ProbA
                        Likelihood = ProbailityOfData(NumberOfFavCases, TotalNumberOfCases)
                    End Function

                    ''' <summary>
                    ''' P(A | B) (Bayes Theorem) P(A | B) = P(B | A) * P(A) / P(B) the posterior
                    ''' probability, is the probability for A after taking into account B for and against A.
                    ''' P(A | B), a conditional probability, is the probability of observing event A given
                    ''' that B is true.
                    ''' </summary>
                    ''' <param name="prior"></param>
                    ''' <param name="Likelihood"></param>
                    ''' <param name="ProbabilityOfData"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function Posterior(ByRef prior As Integer, Likelihood As Integer, ProbabilityOfData As Integer) As Integer
                        Posterior = prior * Likelihood / ProbabilityOfData
                    End Function

                    ''' <summary>
                    ''' P(B | A) * P(A)
                    ''' </summary>
                    ''' <param name="ProbA"></param>
                    ''' <param name="ProbB"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function Prior(ByRef ProbA As Integer, ProbB As Integer) As Integer
                        'P(B | A) * P(A)
                        Prior = BasicProbability.ProbabilityofBgivenA(ProbA, ProbB)
                    End Function

                    ''' <summary>
                    ''' ProbB
                    ''' </summary>
                    ''' <param name="NumberOfFavCases"></param>
                    ''' <param name="TotalNumberOfCases"></param>
                    ''' <returns></returns>
                    ''' <remarks></remarks>
                    Public Shared Function ProbailityOfData(ByRef NumberOfFavCases As Integer, ByRef TotalNumberOfCases As Integer) As Integer
                        'ProbB
                        ProbailityOfData = BasicProbability.ProbablitiyOf(NumberOfFavCases, TotalNumberOfCases)
                    End Function

                End Class

            End Class

        End Namespace

    End Namespace
End Namespace