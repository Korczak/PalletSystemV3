

using Core.Pallet.Common;
using MongoDB.Bson;

namespace Core.Pallets.List
{
    public class PalletInformation
    {
        public ObjectId Id { get; }
        public string RFID { get; }
        public PalletStatus Status { get; }

        public PalletInformation(ObjectId id, string rfid, PalletStatus status)
        {
            Id = id;
            RFID = rfid;
            Status = status;
        }
    }
}
