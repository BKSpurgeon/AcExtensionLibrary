Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
<Assembly: CommandClass(GetType(Samplesvb.AcDbMgdExtensions.DatabaseServices.DatabaseExtensionsCommands))>

Namespace AcDbMgdExtensions.DatabaseServices

    Public Class DatabaseExtensionsCommands : Inherits CommandClass

        '#Region "BlockTable"
        <CommandMethod("BlockTable")>
        Public Sub BlockTable()
            Using trx As Transaction = Db.TransactionManager.StartTransaction
                Dim bt As BlockTable = Db.BlockTable
                Ed.WriteLine(bt.ObjectId)
            End Using
        End Sub
        '#End Region


        '#Region "BlockTableTrx"
        <CommandMethod("BlockTableTrx")>
        Public Sub BlockTableTrx()
            Using trx As Transaction = Db.TransactionManager.StartTransaction
                Dim bt As BlockTable = Db.BlockTable(trx)
                Ed.WriteLine(bt.ObjectId)
            End Using
        End Sub
        '#End Region


        '#Region "DimStyleTable"
        <CommandMethod("DimStyleTable")>
        Public Sub DimStyleTable()
            Using trx As Transaction = Db.TransactionManager.StartTransaction
                Dim dt As DimStyleTable = Db.DimStyleTable
                Ed.WriteLine(dt.ObjectId)
            End Using
        End Sub
        '#End Region


        '#Region "DimStyleTableTrx"
        <CommandMethod("DimStyleTableTrx")>
        Public Sub DimStyleTableTrx()
            Using trx As Transaction = Db.TransactionManager.StartTransaction
                Dim dt As DimStyleTable = Db.DimStyleTable(trx)
                Ed.WriteLine(dt.ObjectId)
            End Using
        End Sub
        '#End Region


             '#Region "LayerTable"
        <CommandMethod("LayerTable")>
        Public Sub LayerTable()
            Using trx As Transaction = Db.TransactionManager.StartTransaction
                Dim lt As LayerTable = Db.LayerTable
                Ed.WriteLine(lt.ObjectId)
            End Using
        End Sub
        '#End Region


        '#Region "LayerTableTrx"
        <CommandMethod("LayerTableTrx")>
        Public Sub LayerTableTrx()
            Using trx As Transaction = Db.TransactionManager.StartTransaction
                Dim lt As LayerTable = Db.LayerTable(trx)
                Ed.WriteLine(lt.ObjectId)
            End Using
        End Sub
        '#End Region






    End Class
End Namespace