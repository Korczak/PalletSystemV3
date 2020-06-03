﻿using PalletSystem.Core.Pallet.Constant;

namespace PalletSystem.Core.Pallet.Add
{
    public class PalletSource
    {
        public string Id { get; }
        public PalletStatus Status { get; }

        public PalletSource(string id, PalletStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}