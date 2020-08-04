using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletProgramStepResult
    {
        public int Index { get; }
        public float Value { get; }
        public int Status { get; }

        public VirtualPalletProgramStepResult(int index, float value, int status)
        {
            Index = index;
            Value = value;
            Status = status;
        }
    }
}
