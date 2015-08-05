using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Autodesk.AutoCAD.DatabaseServices.Contracts
{
 
    /// <summary>
    /// A class for commonly used contracts for Type checks that uses ContractAbbreviotor attribute
    /// </summary>
    //internal static class TypeContracts
    //{
    //   [ContractAbbreviator]
    //   internal static void MustBeSubClass(Type baseType, Type typeDerivesFromBaseType)
    //   {
    //       Contract.Requires(
    //           typeDerivesFromBaseType.IsSubclassOf(baseType),
    //           "Must use type that derives from " + baseType.GetType().Name);
    //   }

    //   [ContractAbbreviator]
    //   internal static void MustDeriveFromEntity(Type typ)
    //   {
    //       Contract.Requires(typ.IsSubclassOf(typeof(Entity)),
    //           "Must use type that derives from Entity or use nonGeneric version Of GetEntity()");
    //   }
    //}
}
