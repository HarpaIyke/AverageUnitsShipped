' Author: Shaheed Ramjohn
' Date: January 24, 2020
' File Name: AverageUnitsShipped
' Purpose: Record the number of units shipped per day, and then calculate the average on the seventh day

Option Strict On

Public Class Form1
    ' Declare and initialize constants
    Const MIN_UNITS As Integer = 0
    Const MAX_UNITS As Integer = 5000
    Const TOTAL_DAYS As Integer = 7

    ' Declare and initialize variables
    Dim currentDay As Integer = 0
    Dim runningTotal As Integer = 0
    Dim input As Integer = 0
    Dim average As Double = 0

    ''' <summary>
    ''' Close the form
    ''' </summary>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Reset the form to its default state
    ''' </summary>
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' Make everything look reset
        txtDisplay.Clear()
        txtEnter.Clear()
        lblDay.Text = "Day 1"
        lblAverage.Text = String.Empty
        btnEnter.Enabled = True

        ' Reset everything behind the scenes
        currentDay = 0
        runningTotal = 0
        txtEnter.ReadOnly = False

        ' Put the focus on to txtEnter
        txtEnter.Focus()
    End Sub

    ''' <summary>
    ''' Validate input and perform necessary calculations
    ''' </summary>
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        ' Verify that input is an integer
        If Integer.TryParse(txtEnter.Text, input) Then

            ' If input is outside the valid range, display an error message
            If input > MAX_UNITS Or input < MIN_UNITS Then
                MessageBox.Show("ERROR! Please enter a value between 0 and 5000!

(Sorry for yelling")
                txtEnter.SelectAll()
                txtEnter.Focus()
            Else

                ' List the entered input if it's before the seventh day
                If currentDay <= TOTAL_DAYS Then

                    ' Display the input, create a new line, increment the current day by one, and reset the entry text box
                    txtDisplay.Text &= input & vbCrLf
                    runningTotal += input
                    currentDay += 1
                    lblDay.Text = "Day " & currentDay
                    txtEnter.Clear()
                    txtEnter.Focus()
                End If

                ' If it's the seventh day, prevent further input and display the average
                If currentDay = 7 Then

                    ' After input for the seventh day has been entered, prevent the user from entering anything more and display the average
                    average = Math.Round((runningTotal / TOTAL_DAYS), 2)
                    txtEnter.ReadOnly = True
                    txtEnter.Clear()
                    btnEnter.Enabled = False
                    lblAverage.Text = "Average units shipped: " & average
                End If
            End If
        Else
            ' Show an error message if the user didn't enter an integer
            MessageBox.Show("ERROR! Please enter an integer!

(Sorry for yelling)")
            txtEnter.SelectAll()
            txtEnter.Focus()
        End If
    End Sub
End Class
