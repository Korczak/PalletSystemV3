using MongoDB.Bson;
using PalletSystem.Core.Pallet.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Pallet.Add
{
    public class PalletSource
    {
        public ObjectId Id { get; }
        public PalletStatus Status { get; }

        public PalletSource(ObjectId id, PalletStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}
