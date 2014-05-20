Public Class Form1
    Const Infinity As Double = 1 / 0

    Private Sub TextBoxes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged
        'Checks if the TextBox.Text can be converted to Double (number)
        Try
            Dim extest As Double = sender.Text  'Will throw error when cannot convert to Double
        Catch
            sender.Text = "0"  'Fix this by setting it back to 0
        End Try
    End Sub

    Public Function IsNegative(ByVal value As Double)
        'If the value is smaller than 0, then it is negative
        If value < 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal args As System.EventArgs) Handles Button1.Click
        'Declaring variables
        'ax+by=e
        'cx+dy=f
        Dim a, b, c, d, e, f As Double
        'Placing actual numbers from TextBoxes to variables
        a = TextBox1.Text  'Why no error here?
        b = TextBox2.Text  'If a value not convertable to Double
        c = TextBox4.Text  'is entered, then the Private Sub
        d = TextBox5.Text  'TextBoxes_TextChanged will fix the error
        e = TextBox3.Text  'before it could even get into variables
        f = TextBox6.Text  'which could return errors.
        'Solving the equations with the opposite coefficients method
        'The program will make the coefficients of x opposite
        'Multiply the equations with opposite coefficients
        'Equation 1
        'ax+by=e /*c
        a = a * c
        b = b * c
        e = e * c
        'Equation 2
        'cx+dy=f /*a
        c = c * TextBox1.Text 'TextBox1.Text should be equal to a.
        d = d * TextBox1.Text 'Why am I using TextBox1.Text instead?
        f = f * TextBox1.Text 'Because the value of the starting a is still in the TextBox, the variable a is changed (a = a * c) 
        'Now the coefficients of x should have the same absolute value
        'But they need to be opposite
        If IsNegative(a) Xor IsNegative(c) Then
            'They are already opposite
        Else
            'They are not opposite (yet)
            'One of the equations needs to be multiplied by -1 to be negative
            'This program makes equation 1 negative
            a = -a
            b = -b
            e = -e
        End If
        'Now they should be opposite
        'Summing the equations
        'After the summing it should look like this:
        '(b+d)y=e+f
        b = b + d
        e = e + f
        'by=e
        'Calculate y by dividing e with b
        Dim y As Double = e / b
        'Use substitution to get the x
        'Since equation 1 has been used all the time now it'll use equation 2
        'cx+dy=f
        d = d * y
        'cx+(d*y)=f
        f = f - d
        'cx=f-(d*y)
        Dim x As Double = f / c
        'x=(f-(d*y))/c
        'The solution should be returned in a MsgBox
        'But the system can have only 1 solution, or no solution, or infinity solutions
        Dim MsgBoxString As String = "(" & x & "," & y & ")"  'This string will display if there is only 1 solution
        If x = Infinity Or y = Infinity Then
            MsgBoxString = "Sustav ima beskonačno mnogo rješenja"  'This string will display if there is infinity solutions
        End If
        Dim xstring As String = x, ystring As String = y  'If x or y equal 0/0, then it is -1.#IND, which is NaN, but NaN is a
        If xstring = "NaN" Or ystring = "NaN" Then        'string so in order to compare we need to convert x and y to string
            MsgBoxString = "Sustav nema rješenja"  'This string will display if there are no solutions
        End If
        MsgBox(MsgBoxString, MsgBoxStyle.Information, "Sustav riješen")  'Display the MsgBox
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub
End Class
