Option Strict On
Public Class Form1

    'Class level variables
    Dim blnFoundFlag(60) As Boolean             'A boolean array to flag the value of the randomly generated values 
    Dim objRandom As Random = New Random()      'Object used to randomly generate values
    Dim intRandomArray(60) As Integer           'Array that holds the value of the random numbers

    Private Sub btnQuickPick_Click(sender As Object, e As EventArgs) Handles btnQuickPick.Click
        'This is the button click event that executes when the user clicks the Quick Pick button.

        'Local variables
        Dim intCount As Integer         'Holds count during loop and used to assign values to appropriate position in array
        Dim intUpper As Integer         'Used to hold the value of the upper bound

        'The For Loop loops five times and assigns the value of the RandomNumber function to the intRandomArray 
        For intCount = 0 To 4

            'Sets the upper bound number so that only numbers 1 through 60 will be generated
            intUpper = 61

            'The RandomNumber function is called and the value returned is assigned to the position in the Array.
            'The position in the array is decided by the count in the For Loop.
            intRandomArray(intCount) = RandomNumber(intUpper)
        Next

        'This code resets the FoundFlag boolean to allow the Cashball number to be a number that had previously been picked
        ReDim blnFoundFlag(60)

        'This changes the upper bound number to only allow numbers from 1 to 4 for the Cashball number
        intUpper = 5

        'The RandomNumber function is called and the value returned is assigned to the sixth position in the Array
        intRandomArray(5) = RandomNumber(intUpper)

        'The following code outputs the values of the randomly generated numbers 
        lblOutput01.Text = intRandomArray(0).ToString
        lblOutput02.Text = intRandomArray(1).ToString
        lblOutput03.Text = intRandomArray(2).ToString
        lblOutput04.Text = intRandomArray(3).ToString
        lblOutput05.Text = intRandomArray(4).ToString
        lblOutput06.Text = intRandomArray(5).ToString

    End Sub


    Function RandomNumber(ByVal intUpper As Integer) As Integer
        'This function generates a random number and returns the value. The random number generated is verified to 
        'be a unique number before being returned.

        'Local variable
        Dim intNum As Integer       'holds the value of the random number generated

        'This generates the random number and verifies the number is unique before exiting the loop
        Do
            'This is the code that generates the random number within the range of 1 to 60 and assigns it to intNum
            intNum = objRandom.Next(1, intUpper)

            'This verifies if the random number generated is unique. If the value of the number is already set to true,
            'then it loops back and generates a new number until it finds a number that has not been flagged yet.
        Loop Until blnFoundFlag(intNum) = False

        'This flags the random number generated for the next time through the loop
        blnFoundFlag(intNum) = True

        'returns the value of the random number generated
        Return intNum

    End Function
End Class
