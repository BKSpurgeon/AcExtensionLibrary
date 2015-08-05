using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class BlockReferenceExtensions
    {
        public static BlockTableRecord GetEffectiveBlockTableRecord(this BlockReference blockref, Transaction trx)
        {
            if (blockref.IsDynamicBlock)
            {
                return blockref.DynamicBlockTableRecord.GetDBObject<BlockTableRecord>(trx, OpenMode.ForRead, false);
            }
            return blockref.BlockTableRecord.GetDBObject<BlockTableRecord>(trx, OpenMode.ForRead, false);
        }

        public static BlockTableRecord GetEffectiveBlockTableRecord(this BlockReference blockref)
        {
            return blockref.GetEffectiveBlockTableRecord(blockref.Database.TransactionManager.TopTransaction);
        }

        public static string GetEffectiveName(this BlockReference blockref, Transaction trx)
        {
            if (blockref.IsDynamicBlock)
            {
                return blockref.DynamicBlockTableRecord.GetDBObject<BlockTableRecord>(trx, OpenMode.ForRead, false).Name;
            }
            return blockref.Name;
        }

        public static string GetEffectiveName(this BlockReference blockref)
        {
            return blockref.GetEffectiveName(blockref.Database.TransactionManager.TopTransaction);
            
        }

        public static IEnumerable<AttributeReference> GetAttributeReferences(this BlockReference bref, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }
            if (includingErased)
            {
                foreach (ObjectId id in bref.AttributeCollection)
                {

                    yield return (AttributeReference)trx.GetObject(id, mode, true, openObjectsOnLockedLayers);

                } 
            }
            else
            {
                foreach (ObjectId id in bref.AttributeCollection)
                {
                    if (!id.IsErased)
                    {
                        yield return (AttributeReference)trx.GetObject(id, mode, false, openObjectsOnLockedLayers);
                    }
                    

                } 
            }


        }

        public static IEnumerable<AttributeReference> GetAttributeReferences(this BlockReference bref, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
        {
            return bref.GetAttributeReferences(bref.Database.TransactionManager.TopTransaction, mode, includingErased, openObjectsOnLockedLayers);

        }

        public static Dictionary<string, AttributeReference> GetAttributeReferenceDictionary(this BlockReference bref, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }

            return bref.GetAttributeReferences(trx, mode, includingErased, openObjectsOnLockedLayers).ToDictionary(a => a.Tag);

        }

        public static Dictionary<string, AttributeReference> GetAttributeReferenceDictionary(this BlockReference bref, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
        {
            return bref.GetAttributeReferenceDictionary(bref.Database.TransactionManager.TopTransaction, mode, includingErased, openObjectsOnLockedLayers);

        }
    }
}
