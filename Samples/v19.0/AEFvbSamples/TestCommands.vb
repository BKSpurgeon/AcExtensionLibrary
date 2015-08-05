Imports System.Linq
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime


Public Class TestCommands
    Inherits CommandClass
    ''' <summary>
    ''' Command for printing layers
    ''' </summary>
    <CommandMethod("PrintLayers")> _
    Public Sub PrintLayers()
        Using trx As Transaction = Db.TransactionManager.StartTransaction()
            Dim lt As LayerTable = Db.LayerTable()
            Dim layers = lt.GetLayerTableRecords().Names()
            Ed.WriteLine(layers)
            trx.Commit()
        End Using
    End Sub
    ''' <summary>
    ''' Command for printing Blocks
    ''' </summary>
    <CommandMethod("PrintBlocks")> _
    Public Sub PrintBlocks()
        Using trx As Transaction = Db.TransactionManager.StartTransaction()
            Dim bt As BlockTable = Db.BlockTable()
            Dim blocks = bt.GetBlockTableRecords().Names()
            Ed.WriteLine(blocks)
            trx.Commit()
        End Using
    End Sub



    ''' <summary>
    ''' Command for printing Groups and uses a class that wraps a DBDictionary for GroupDictionary
    ''' </summary>
    <CommandMethod("PrintGroups")> _
    Public Sub PrintGroups()
        Using trx As Transaction = Db.TransactionManager.StartTransaction()
            Dim grpDic As GroupDictionary = Db.GroupDictionary()
            For Each grp As Group In grpDic
                Ed.WriteLine(grp.Name)
            Next

            trx.Commit()
        End Using
    End Sub

    ''' <summary>
    ''' Just uses extension methods unlike above
    ''' </summary>
    <CommandMethod("PrintGroups2")> _
    Public Sub PrintGroups2()
        Using trx As Transaction = Db.TransactionManager.StartTransaction()
            Dim grpDic As DBDictionary = Db.GroupDBDictionary()
            Dim groups = grpDic.GetEntries(Of Group)()
            For Each grp As Group In groups
                Ed.WriteLine(grp.Name)
            Next

            trx.Commit()
        End Using
    End Sub

    ''' <summary>
    ''' Print line length for each line
    ''' </summary>
    <CommandMethod("PrintLinesLength")> _
    Public Sub PrintLinesLength()
        Using trx As Transaction = Db.TransactionManager.StartTransaction()
            Dim model As BlockTableRecord = Db.ModelSpace()
            Dim lines = model.GetEntities(Of Line)()
            For Each line As Line In lines
                Ed.WriteLine(line.Length)
            Next

            trx.Commit()
        End Using
    End Sub

    ''' <summary>
    ''' Get total length of all lines in model space
    ''' </summary>
    <CommandMethod("PrintTotalLinesLength")> _
    Public Sub PrintTotalLinesLength()
        Using trx As Transaction = Db.TransactionManager.StartTransaction()
            Dim model As BlockTableRecord = Db.ModelSpace()
            Dim linesLength = model.GetEntities(Of Line)().Sum(Function(l) l.Length)
            Ed.WriteLine(linesLength)

            trx.Commit()
        End Using
    End Sub


    '<CommandMethod("MBI")> _
    'Public Sub MBI()
    '    Dim pso As New PromptStringOptions(vbLf & "BlockName")
    '    pso.AllowSpaces = True
    '    Dim pr As PromptResult = Ed.GetString(pso)

    '    If pr.Status <> PromptStatus.OK Then
    '        Return
    '    End If

    '    Dim cmd As New ScriptCommand("_.-INSERT", pr.StringResult)
    '    cmd.WaitForExit = True

    '    Dim ps As PromptStatus = PromptStatus.OK

    '    While Not HostApplicationServices.Current.UserBreak() AndAlso ps = PromptStatus.OK
    '        ps = cmd.Run()
    '    End While
    'End Sub

End Class


