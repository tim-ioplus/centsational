Imports System.Threading
Imports Domain


Module Module1

    Sub Main()
        ' Step 1: declare two-dimensional array of strings.
        Dim values(,) As String =
            New String(,) {{"AA", "BB"},
                           {"CC", "DD"}}

        ' Step 2: get bounds of the array.
        Dim bound0 As Integer = values.GetUpperBound(0)
        Dim bound1 As Integer = values.GetUpperBound(1)

        Dim text As String = ""

        ' Step 3: loop over all elements.
        For i As Integer = 0 To bound0
            For x As Integer = 0 To bound1
                ' Get element.
                Dim s1 As String = values(i, x)
                text += s1
                Console.Write(s1)
                Console.Write(" "c)
            Next
            Console.WriteLine()
        Next

        ' Step 4: print the result.
        Console.WriteLine(text)
        Thread.Sleep(1000)

        ' Step 5: wait for key press.

        Console.WriteLine("Press any key to count")
        Dim entered As ConsoleKeyInfo = Console.ReadKey()
        Console.WriteLine()

        Thread.Sleep(500)
        Console.WriteLine("entered: " + entered.KeyChar + " " + entered.Key.ToString())

        ' Step 6: count occurrences of a character in a string.
        Dim counter As New CharCounter()
        Dim count As Integer = counter.CountCharOccurrences(text, entered.KeyChar)

        Console.WriteLine("Count of " + entered.KeyChar + " is " + count.ToString())

        Console.WriteLine("quit in 5sec")
        Thread.Sleep(2500)


    End Sub

    Class CharCounter
        Public Function CountCharOccurrences(input As String, targetChar As Char) As Integer
            If input Is Nothing Then
                Throw New ArgumentNullException(NameOf(input))
            End If

            Dim count As Integer = 0
            For Each c As Char In input
                If c = targetChar Then
                    count += 1
                End If
            Next
            Return count
        End Function

    End Class

End Module
