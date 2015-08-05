using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices.Contracts;
using System.Diagnostics.Contracts;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.EditorInput;
namespace Autodesk.AutoCAD.DatabaseServices
{
 public static class BlockTableRecordExtensions
    {

        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=41311.msg464529#msg464529
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
     public static IEnumerable<BlockTableRecord> UserDefinedBlocks(this IEnumerable<BlockTableRecord> source)
     {
         return source.Where(btr =>
             !(
             btr.IsAnonymous ||
             btr.IsFromExternalReference ||
             btr.IsFromOverlayReference ||
             btr.IsLayout ||
             btr.IsAProxy
             )
             );
     }

     public static IEnumerable<BlockTableRecord> UserCreatedBlocks(this IEnumerable<BlockTableRecord> source)
     {
         return source.Where(btr =>
             !(
             btr.IsFromExternalReference ||
             btr.IsFromOverlayReference ||
             btr.IsLayout ||
             btr.IsAProxy
             )
             );
     }
        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=41311.msg464529#msg464529
        /// Use instead of UserDefinedBlocks when anonymous blocks are needed
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
     public static IEnumerable<BlockTableRecord> NonDependent(this IEnumerable<BlockTableRecord> source)
     {
         return source.Where(btr =>
             !(
             btr.IsFromExternalReference ||
             btr.IsFromOverlayReference
             )
             );
     }


     public static IEnumerable<ObjectId> GetObjectIds<T>(this BlockTableRecord btr) where T : Entity
     {
         IntPtr impobj = RXClass.GetClass(typeof(T)).UnmanagedObject;
         foreach (ObjectId id in btr)
         {
             if (id.ObjectClass.UnmanagedObject == impobj)
             {
                 yield return id;
             }
         }
     }

     public static IEnumerable<ObjectId> GetObjectIds(this BlockTableRecord btr)
     {
         foreach (ObjectId id in btr)
         {
             yield return id;
         }
     }

        /// <summary>
        /// Author: Tony Tanzillo
        /// A combination of code written by Tony Tanzillo from 2 sources below
        /// Source1: http://www.theswamp.org/index.php?topic=42197.msg474011#msg474011
        /// Source2: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <param name="btr"></param>
        /// <param name="mode"></param>
        /// <param name="openErased"></param>
        /// <param name="openObjectsOnLockedLayers"></param>
        /// <returns></returns>
     public static IEnumerable<Entity> GetEntities(this BlockTableRecord btr, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }

            foreach (ObjectId id in includingErased ? btr.IncludingErased : btr)
            {
                yield return (Entity)trx.GetObject(id, mode, includingErased, openObjectsOnLockedLayers);
            }

        }

        public static IEnumerable<Entity> GetEntities(this BlockTableRecord btr, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
        {
            return btr.GetEntities(btr.Database.TransactionManager.TopTransaction, mode, includingErased, openObjectsOnLockedLayers);

        }

        /// <summary>
        /// Author: Tony Tanzillo
        /// A combination of code written by Tony Tanzillo from 2 sources below
        /// Source1: http://www.theswamp.org/index.php?topic=42197.msg474011#msg474011
        /// Source2: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="btr"></param>
        /// <param name="mode"></param>
        /// <param name="openErased"></param>
        /// <param name="openObjectsOnLockedLayers"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetEntities<T>(this BlockTableRecord btr, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false) where T : Entity
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }

            IntPtr impObject = RXClass.GetClass(typeof(T)).UnmanagedObject;


            foreach (ObjectId id in includingErased ? btr.IncludingErased : btr)
            {
                if(id.ObjectClass.UnmanagedObject == impObject)
                {
                    yield return (T)trx.GetObject(id, mode, includingErased, openObjectsOnLockedLayers);
                }

            }
        }

        public static IEnumerable<T> GetEntities<T>(this BlockTableRecord btr, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false) where T : Entity
        {
            return btr.GetEntities<T>(btr.Database.TransactionManager.TopTransaction, mode, includingErased, openObjectsOnLockedLayers);
        }

        /// <summary>
        /// Author: Tony Tanzillo
        /// A combination of code written by Tony Tanzillo from 2 sources below
        /// Source1: http://www.theswamp.org/index.php?topic=42197.msg474011#msg474011
        /// Source2: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="btr"></param>
        /// <param name="mode"></param>
        /// <param name="openErased"></param>
        /// <param name="openObjectsOnLockedLayers"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetEntitiesAssignableFrom<T>(this BlockTableRecord btr, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false) where T : Entity
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }

            RXClass rxclass = RXClass.GetClass(typeof(T));


            foreach (ObjectId id in includingErased ? btr.IncludingErased : btr)
            {
                if (id.ObjectClass.IsDerivedFrom(rxclass))
                {
                    yield return (T)trx.GetObject(id, mode, includingErased, openObjectsOnLockedLayers);
                }

            }

        }

        public static IEnumerable<T> GetEntitiesAssignableFrom<T>(this BlockTableRecord btr, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false) where T : Entity
        {
            return btr.GetEntitiesAssignableFrom<T>(btr.Database.TransactionManager.TopTransaction, mode, includingErased, openObjectsOnLockedLayers);

        }
     /// <summary>
     /// Method for getting all blockreference Ids
     /// </summary>
     /// <param name="btr"></param>
     /// <param name="directOnly"></param>
     /// <param name="forceValidity"></param>
     /// <param name="trx"></param>
     /// <returns></returns>
        public static ObjectIdCollection GetAllBlockReferenceIds(this BlockTableRecord btr, Transaction trx, bool directOnly, bool forceValidity)
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }

            ObjectIdCollection blockReferenceIds = btr.GetBlockReferenceIds(directOnly, forceValidity);

         if (!btr.IsDynamicBlock) return blockReferenceIds;
         foreach (ObjectId id in btr.GetAnonymousBlockIds())
         {
             BlockTableRecord record = trx.GetObject(id, OpenMode.ForRead) as BlockTableRecord;
             blockReferenceIds.Add(record.GetBlockReferenceIds(directOnly, forceValidity));

         }
         return blockReferenceIds;
        }

        public static ObjectIdCollection GetAllBlockReferenceIds(this BlockTableRecord btr, bool directOnly, bool forceValidity)
        {
            return btr.GetAllBlockReferenceIds(btr.Database.TransactionManager.TopTransaction, directOnly, forceValidity);
        }
        public static void CreatePreviewIcon(this BlockTableRecord btr)
        {
            Application.DocumentManager.MdiActiveDocument.Editor.AcedCmd("_.BLOCKICON", btr.Name);
        }
     public static IEnumerable<AttributeDefinition> GetAttributeDefinitions(this BlockTableRecord btr, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
     {

         return btr.GetEntities<AttributeDefinition>(trx, mode, includingErased, openObjectsOnLockedLayers);
     }

     public static IEnumerable<AttributeDefinition> GetAttributeDefinitions(this BlockTableRecord btr, OpenMode mode = OpenMode.ForRead, bool includingErased = false, bool openObjectsOnLockedLayers = false)
     {
         return btr.GetAttributeDefinitions(btr.Database.TransactionManager.TopTransaction, mode, includingErased, openObjectsOnLockedLayers);
     }
    }
}

