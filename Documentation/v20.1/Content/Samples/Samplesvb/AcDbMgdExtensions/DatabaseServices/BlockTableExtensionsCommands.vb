Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime

<Assembly: CommandClass(GetType(Samplesvb.AcDbMgdExtensions.DatabaseServices.BlockTableExtensionsCommands))>

Namespace AcDbMgdExtensions.DatabaseServices
    Public Class BlockTableExtensionsCommands
        Inherits CommandClass
        '#Region "GetBlockTableRecords"
        <CommandMethod("GetBlockTableRecords")>
        Public Sub GetBlockTableRecords()
            Using trx As Transaction = Db.TransactionManager.StartTransaction()
                Dim bt As BlockTable = Db.BlockTable()
                Dim blocks = bt.GetBlockTableRecords()
                For Each blk As Object In blocks
                    Ed.WriteLine(String.Format("Contains {0} this many entities in BlockTableRecord", blk.GetObjectIds().Count()))
                Next
            End Using
        End Sub
        '#End Region

        '#Region "GetBlockTableRecordsOpenForWrite"
        <CommandMethod("GetBlockTableRecordsOpenForWrite")>
        Public Sub GetBlockTableRecordsOpenForWrite()
            Using trx As Transaction = Db.TransactionManager.StartTransaction()
                Dim bt As BlockTable = Db.BlockTable()
                Dim blocks = bt.GetBlockTableRecords(OpenMode.ForWrite)


                For Each blk As Object In blocks
                    Ed.WriteLine(String.Format("Contains {0} this many entities in BlockTableRecord", blk.GetObjectIds().Count()))
                Next
            End Using
        End Sub
        '#End Region

        '#Region "GetBlockTableRecordsOpenForReadAndXrefBlocks"
        <CommandMethod("GetBlockTableRecordsOpenForReadAndXrefBlocks")>
        Public Sub GetBlockTableRecordsOpenForReadAndXrefBlocks()
            Using trx As Transaction = Db.TransactionManager.StartTransaction()
                Dim bt As BlockTable = Db.BlockTable()
                Dim blocks = bt.GetBlockTableRecords(OpenMode.ForRead, SymbolTableRecordFilter.IncludeDependent)

                For Each blk As Object In blocks
                    Ed.WriteLine(String.Format("Contains {0} this many entities in BlockTableRecord", blk.GetObjectIds().Count()))
                Next
            End Using
        End Sub
        '#End Region
    End Class
End Namespace

