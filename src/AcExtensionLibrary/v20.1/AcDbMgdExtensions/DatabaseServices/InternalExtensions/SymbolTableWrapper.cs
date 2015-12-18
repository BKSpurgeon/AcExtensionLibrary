using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices.InternalExtensions
{
    public class SymbolTableWrapper<T> : IDisposable, IEnumerable<T> where T : SymbolTableRecord
    {
        private SymbolTable symbolTbl { get; set; }
        private Transaction trx { get; set; }
        private SymbolTableRecordFilter filter { get; set; }

        public SymbolTableWrapper(Transaction trx, SymbolTable symbolTable, OpenMode mode, SymbolTableRecordFilter filter)
        {
            this.trx = trx;
            this.symbolTbl = symbolTbl;
            this.filter = filter;
        }

        public SymbolTableWrapper(SymbolTable symbolTable, OpenMode mode, SymbolTableRecordFilter filter) 
            :this(symbolTable.Database.TransactionManager.TopTransaction, symbolTable, mode, filter)
        {

        }

        public void Dispose()
        {
            symbolTbl.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
