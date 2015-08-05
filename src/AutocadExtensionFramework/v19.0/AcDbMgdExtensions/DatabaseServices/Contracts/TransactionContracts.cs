using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Autodesk.AutoCAD.Runtime;
namespace Autodesk.AutoCAD.DatabaseServices.Contracts
{
    /// <summary>
    /// A class for commonly used contracts for transactions that uses ContractAbbreviotor attribute
    /// </summary>
    internal static class TransactionContracts
    {
       //[ContractAbbreviator]
       //internal static void TransactionActive(Transaction trx, Database db)
       //{
       //    Contract.Requires(trx != null | db.TransactionManager.TopTransaction != null, "No active transactions");
       //}
       // [ContractAbbreviator]
       //internal static void TransactionActive(Transaction trx, DBObject dbo)
       //{
       //    Contract.Requires(trx != null | dbo.Database.TransactionManager.TopTransaction != null);
       //}

    }
}
