'----------------------------------------------------------------------------------'
'--------- this class contains all the instructions for drawing a 3D model --------'
'----------------------------------------------------------------------------------'
Imports OpenTK
Imports OpenTK.Platform
Imports OpenTK.Graphics.OpenGL
Imports System.Math

Public Class FingerBall
    Public mesh As MeshVbo
    Public meshRed As MeshVbo
    Public pos(2) As Single
    Public ang(2) As Single
    Public scale As Single

    Public RedMode As Boolean

    '----------------------------------------------------------------------------------'
    '--------------------------------- default constructor ----------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub New(ByVal fName As String, ByRef modPos() As Single, ByRef modAng() As Single, ByVal modS As Single)
        mesh = New MeshVbo(poly.TRIS)
        mesh.readWavefront(fName & ".obj")
        mesh.loadVbo()

        meshRed = New MeshVbo(poly.TRIS)
        meshRed.readWavefront("ballr" & ".obj")
        meshRed.loadVbo()

        pos = modPos
        ang = modAng
        scale = modS
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------------- draw target ---------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub drawModel()

        GL.PushMatrix()
        GL.Translate(pos(0), pos(1), pos(2))
        GL.Scale(scale, scale, scale)
        GL.Rotate(ang(0), 1, 0, 0)
        GL.Rotate(ang(1), 0, 1, 0)
        GL.Rotate(ang(2), 0, 0, 1)
        If RedMode Then
            meshRed.drawVbo()
        Else
            mesh.drawVbo()
        End If

        GL.PopMatrix()

    End Sub

End Class
