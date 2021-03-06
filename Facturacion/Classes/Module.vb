﻿Imports System.Data.OleDb

Module Module1
    Public DB As Connection = New Connection
    Public trans As OleDbTransaction
    Public RA As Long 'Registros Afectados
    Public TA As Boolean 'Para transacciones abiertas
    Public NF As Long 'Numero de Factura
    Public NC As Long 'Numero de Cotizacion
    Public frmfactura As New Form1
    Public Empresa As String
    Public EsloganEmp As String
    Public DireccionEmp As String
    Public TelefonoEmp As String
    Public RncEmp As String
    Public EmailEmp As String
    Public Valida As String
    Public FmantFacturas As New frmMantFacturas
    Public FmantCotizacion As New frmMantCotizacion
    Public Ffactura As New Form1
    'Public Freportes As New Reportes

    Public Sub insertar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = DB.Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)
    End Sub

    Public Sub Eliminar(myQuery As String)
        Dim cmd As OleDbCommand = New OleDbCommand(myQuery)
        cmd.Connection = DB.Cnn
        cmd.ExecuteNonQuery()
        MsgBox("Eliminado Con Éxito", MsgBoxStyle.Information)
    End Sub

    Public Function Comprobante(fijo As String, ncfsec As Long) As String
        Dim ncf As String
        Dim f As String = "0"

        For i = Len(ncfsec.ToString) To 6
            f &= "0"
        Next i
        ncf = fijo & f & ncfsec.ToString
        Return ncf

    End Function

    Function Efecha(Fecha As String) As String
        Dim Resul As String

        Resul = Mid(Fecha, 7, 4) & "/" & Mid(Fecha, 4, 2) & "/" & Mid(Fecha, 1, 2)
        Return Resul
    End Function

    Function Lfecha(Fecha As String) As String
        Dim Resul As String

        Resul = Mid(Fecha, 9, 2) & "/" & Mid(Fecha, 6, 2) & "/" & Mid(Fecha, 1, 4)
        Return Resul
    End Function

    Function Cambiar(Valor As String) As String
        Dim Cadena As String
        Cadena = Replace(Valor, "'", "´", 1)
        Return Cadena
    End Function

End Module

