Imports System
Imports System.Windows.Forms

'This comment is an initial test of Mercurial/TortiseHG push process -SUMNER (03/07/13)

Module Module1

    'Public GAMEPATH As String = "C:\ROBOTIC LAB\Hand Rehabilitation Robot\expo2012\gameWindowExp\"
    '' testing out version control
    Public GAMEPATH As String = Application.StartupPath
    Public positions() As Double = {2.25, 1.15, 0.0, -1.15, -2.25}
    Public FPS As Double = 200
    Public diagnostic As Boolean = False

    Public currentSub As Subject
    Public currentSong As Song
    Public trialStr As String = ""

    Public menu As Menu

    Sub Main()
        GAMEPATH = GAMEPATH.Substring(0, GAMEPATH.LastIndexOf("\"))
        GAMEPATH = GAMEPATH.Substring(0, GAMEPATH.LastIndexOf("\") + 1)
        makeAbsentDirectories()

        Application.EnableVisualStyles()
        menu = New Menu
        Application.Run(menu)

    End Sub

    ''------------------------------- make absent directories ---------------------------''
    '' HG will not track empty directories, and we don't want it to track folders full of
    '' data. As such, we need to make our data directories if they do not exist
    Sub makeAbsentDirectories()
        If (Not System.IO.Directory.Exists(GAMEPATH & "dataFiles")) Then
            System.IO.Directory.CreateDirectory(GAMEPATH & "dataFiles")
        End If

        If (Not System.IO.Directory.Exists(GAMEPATH & "gainFiles")) Then
            System.IO.Directory.CreateDirectory(GAMEPATH & "gainFiles")
        End If

        If (Not System.IO.Directory.Exists(GAMEPATH & "hitTimeFiles")) Then
            System.IO.Directory.CreateDirectory(GAMEPATH & "hitTimeFiles")
        End If

        If (Not System.IO.Directory.Exists(GAMEPATH & "scoreFiles")) Then
            System.IO.Directory.CreateDirectory(GAMEPATH & "scoreFiles")
        End If

        If (Not System.IO.Directory.Exists(GAMEPATH & "Subjects")) Then
            System.IO.Directory.CreateDirectory(GAMEPATH & "Subjects")
            Console.WriteLine("made subjects dir")
        End If

        If (Not System.IO.File.Exists(GAMEPATH & "Subjects\" & "default.txt")) Then
            Dim defaultSubjectFile As New System.IO.StreamWriter(GAMEPATH & "Subjects\" & "default.txt")
            defaultSubjectFile.WriteLine("0")
            defaultSubjectFile.WriteLine("default")
            defaultSubjectFile.WriteLine("9/9/2011 12:00:00 AM")
            defaultSubjectFile.Close()
            Console.WriteLine("made subjects file")
        End If

        If (Not System.IO.File.Exists(GAMEPATH & "Subjects\" & "allSubjects.txt")) Then
            Dim allSubjectFile As New System.IO.StreamWriter(GAMEPATH & "Subjects\" & "allSubjects.txt")
            allSubjectFile.WriteLine("default")
            allSubjectFile.Close()
        End If

    End Sub

End Module
