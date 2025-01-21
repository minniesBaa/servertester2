Imports System

Public Module flag


    Public Function getarg() As String

        Dim args As String() = Environment.GetCommandLineArgs()


        If args.Length > 1 Then

            Dim firstFlag As String = args(1)

            ' get flag 1
            Console.WriteLine("First flag: " & firstFlag)
            Return (firstFlag)
        Else
            Console.WriteLine("No flags provided.")
            Return ("")
        End If

    End Function

End Module
